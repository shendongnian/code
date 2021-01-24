    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
    
        private Vector2 m_Direction;
    
        void Start()
        {
            // save direction by offsetting the target position and the initial object's position.
            m_Direction= Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        }
    
        void Update()
        {
            // this will cause to every frame the object's transform to be move towards the target position direction.
            transform.position = Vector2.MoveTowards(this.transform.position, this.transform.position + m_Direction, speed * Time.deltaTime);
        }
    
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.name.Equals("Player") && !collision.name.Equals("Bullet(Clone)"))
            {
                Destroy(gameObject);
            }
        }
    }
