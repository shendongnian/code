    using UnityEngine;
    
    public class Player : MonoBehaviour
    {
        Vector3 velocityBeforeCollisions = Vector3.zero;
        Rigidbody body = null;
        float health = 1f;
    
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }
    
        void FixedUpdate()
        {
            velocityBeforeCollisions = body.velocity;
        }
    
        public float GetSpeed()
        {
            return velocityBeforeCollisions.magnitude;
        }
    
        void OnCollisionEnter(Collision collision)
        {
            Player otherPlayer = collision.gameObject.GetComponent<Player>();
            if (otherPlayer != null && otherPlayer.GetSpeed() > GetSpeed())
            {
                Damage();
            }
        }
    
        public void Damage()
        {
            Debug.Log(name + " damaged");
            health -= 0.1f;
        }
    
    }
