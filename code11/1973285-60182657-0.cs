    using UnityEngine;
    
    public class playermove : MonoBehaviour
    {
        public float moveSpeed = 5f;
    
    
        // Update is called once per frame
        void Update()
        {
            jump();
            Vector3 movment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movment * Time.deltaTime * moveSpeed;
        }
        void jump()
        {
            if (Input.GetButtonDown("jump")) ;
            gameObject.GetComponent<RigidBody2D>(); AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    
    }
