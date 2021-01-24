    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class EnemyMove : MonoBehaviour
    {
        public Transform target;
        public float speed = 10f;
    
        public Transform rb;
    
        void Start()
        {
            //You can get these programatically or attach them ni the editor. Seems that 
            //target is the player and the rb is the follower. You can make the variables 
            //public attach them in the editor so that they can be accessed in the code
            // rb = GetComponent<Rigidbody2D>();
            // target = 
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            Vector3 dir = target.position - rb.position;
            rb.position = rb.position + (dir.normalized * speed);
        }
    }
