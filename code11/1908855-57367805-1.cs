    using UnityEngine;
    using System.Collections;
    
    public class BallMovement : MonoBehaviour
    {
    
        public float speed;
        private Rigidbody rb;
    
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        private void Update()
        {
            Camera mainCamera = GameObject.FindGameObjectWithTag("8BallCamera").GetComponent<Camera>() as Camera;
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = mainCamera.transform.forward * moveVertical * 30;
            rb.AddForce(movement * speed);
    
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(0, 2f, 0, ForceMode.Impulse);
            }
        }
    }
