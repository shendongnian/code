    using UnityEngine;
    
    public class CubeControl : MonoBehaviour
    {
        public Rigidbody rb;
    
        public float forwardForce = 2000f;
        public float sidewaysForce = 500f;
        public float acceleration = 1;
    
        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            forwardForce += Time.deltaTime * acceleration;
    
            //Using the in-built methods uses the keys you were but also the arrow keys
            float inputX = Input.GetAxis("Horizontal");
    
            //Check there is input
            if (Mathf.Abs(inputX) > float.Epsilon)
            {
                //set which force direction to use by comparing the inputX value
                float force = inputX > 0 ? sidewaysForce : -sidewaysForce;
                rb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
    
        }
    }
