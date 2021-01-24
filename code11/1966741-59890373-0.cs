     using UnityEngine;
     using System.Collections;
     
     public class MouseMovement : MonoBehaviour {
     
         public float speed = 10f;
         // Use this for initialization
         void Start () {
             Vector3 playerpos = transform.position;
         }
         
         // Update is called once per frame
         void Update () {
             if (Input.GetKeyDown(KeyCode.Mouse0)) 
             {
                 Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(input.mousepos.x,input.mousepos.y);
                 transform.position = Vector3.MoveTowards(transform.position,mousePos,speed * time.deltatime);
                 
             }
     
         }
     }
