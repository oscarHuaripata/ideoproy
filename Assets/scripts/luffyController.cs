using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luffyController : MonoBehaviour
{
    public float velocidad = 5;
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_PUÑO = 2;
    private const int ANIMATION_REDHAWK= 3;
    private const int ANIMATION_CAE = 4;
    private const int ANIMATION_SALTAR=5;
    private const int ANIMATION_PUÑO_3MARCHA=6;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool EstaSaltando = false;
    public float fuerzaSalto = 8;
    public BoxCollider2D plataform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
            {
                CambiarAnimacion(ANIMATION_SALTAR);
                Saltar();
                EstaSaltando = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))//Si presiono la tecla rigtharrow voy a ir hacia la derecha
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha
                
                if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
                {
                    CambiarAnimacion(ANIMATION_SALTAR);
                    Saltar();
                    EstaSaltando = true;
                }
            }
            
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                CambiarAnimacion(ANIMATION_CORRER);
                spriteRenderer.flipX = true;
                /*if(Input.GetKey(KeyCode.C))
                {
                    
                    CambiarAnimacion(ANIMATION_SLIDE);
                }
            */if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
                {
                    CambiarAnimacion(ANIMATION_SALTAR);
                    Saltar();
                    EstaSaltando = true;
                }
            }else if (Input.GetKey(KeyCode.C))
            {
               CambiarAnimacion(ANIMATION_PUÑO);
            }else if (Input.GetKey(KeyCode.V))
            {
               CambiarAnimacion(ANIMATION_REDHAWK);
            }else if (Input.GetKey(KeyCode.F))
            {
               CambiarAnimacion(ANIMATION_PUÑO_3MARCHA);
            } else if(EstaSaltando==false)
            {
                CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
                rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
            }
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
      private void Saltar()
    {
        CambiarAnimacion(ANIMATION_SALTAR);
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        EstaSaltando = false;
        /*if(cont==2){
            if(estaPlaneando==false){
                EstaMuerto=true;
                vidas--;
                }
        }
        cont=0;*/
         
        /*if (other.gameObject.tag == "Enemy")
        {
            esIntangible = true;
        }*/
    }
}
