using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScriptss : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed = 0.2f;
    public Animator anmi;
    public SpriteRenderer render;
    public LayerMask jupableGround;
    public BoxCollider2D coll;
    public float height = 7.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = RB.velocity.y;
        if (Input.GetButtonDown("Jump"))
        {
            movement = Vector2.up * height;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anmi.SetTrigger("attack");
        }
        if (movement.x < 0)
        {
            render.flipX = true;
        }
        else if (movement.x > 0)
        {
            render.flipX = false;
        }
        anmi.SetBool("isMoving", movement.x != 0);
        anmi.SetBool("isGrounded", isGrounded());
        anmi.SetFloat("yVelocity", movement.y);
        RB.velocity = movement;
    }
    public bool isGrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            jupableGround);
    }
}
