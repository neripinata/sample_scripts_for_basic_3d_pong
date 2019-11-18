using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float velocity;
    public float caer = 1;
    public int c;
    public int clock = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Decide si la pelota va para la izquierda o la derecha
        float direccion = Random.Range(0.0f,5.0f);
        if (direccion > 2.5)
        {
            velocity = 0.1f;
        }
        else
        {
            velocity = -0.1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity, 0, 0);
        transform.Translate(0, caer, 0);

        if (c == 1)
        {
            velocity = -velocity;
            c = 2;
        }
        if (c ==0)
        {
            caer = -caer;
            c = 2;
        }
        if (velocity > 0 && clock==450)
        {
            velocity += 0.1f;
        }
        if (velocity < 0 && clock == 450)
        {
            velocity -= 0.1f;
        }
        if (c == 69)
        {
            Debug.Log("Player one, you lose");
            velocity = 0;
            caer = 0;
        }
        if (c == 420)
        {
            Debug.Log("Player two, you lose");
            velocity = 0;
            caer = 0;
        }


        clock += 1;
        if (clock == 451)
        {
            clock = 0;
        }


        Debug.Log(velocity);
        Debug.Log(clock);

    }

    //Sistema de Rebote, ya sea al tocar laterales, piso o techo
    int OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "barra")
        {
            c = 1;
        }
        if (other.gameObject.tag == "piso")
        {
            c = 0;
        }
        if (other.gameObject.tag == "lose")
        {
            c = 69;
        }
        if (other.gameObject.tag == "lose_second")
        {
            c = 420;
        }
        return c;

    }


   



    

}
