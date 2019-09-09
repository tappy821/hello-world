using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D RG;
    private int jump_counter = 2;
    public float walk_speed=3.0f;
    public float y_velocity=5.0f;
      void Start()
    {
        RG = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(jump_counter >0){
        if(Input.GetKeyDown(KeyCode.Space)){
            RG.velocity = new Vector2(RG.velocity.x,y_velocity);
            jump_counter --;
        }
        }
        if(Input.GetAxisRaw("Horizontal")>0){
            this.transform.position = new Vector3(transform.position.x+0.01f*walk_speed,transform.position.y,0);
        }
        if(Input.GetAxisRaw("Horizontal")<0){
             this.transform.position=new Vector3(transform.position.x-0.01f*walk_speed,transform.position.y,0);
        }
        if(Input.GetAxisRaw("Horizontal") == 0){
           // RG.velocity = new Vector2(0,RG.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D Col){
        if(Col.gameObject.tag == "floor" ){
            if(jump_counter <= 2){
                jump_counter = 2;
            }
        }
    }
}
