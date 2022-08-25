using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    float jumFor = 25;


    private const int animation_quieto = 0;
    private const int animation_correr = 1;
    private const int animation_saltar = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(animation_quieto);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5,rb.velocity.y);
            sprite.flipX = true;
            changeAnimation(animation_correr);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5,rb.velocity.x);
            sprite.flipX = false;
            changeAnimation(animation_correr);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0,jumFor),ForceMode2D.Impulse);
            changeAnimation(animation_saltar);
        }
    }
    void changeAnimation(int animation)
    {
        animator.SetInteger("estado",animation);
    }
}
