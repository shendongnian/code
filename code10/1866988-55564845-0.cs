    public class Example : MonoBehaviour
    {
        public GameObject explosion;
        public bool isGrounded;
    
        private void Start()
        {
            Invoke("RemoveRocket", 5);
        }
    
        private void FixedUpdate()
        {
            if (!isGrounded)
            {
                MoveRocket();
            }
        }
    
        private void MoveRocket()
        {
            transform.position += (transform.right / .1f) * Time.deltaTime;
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                Instantiate(explosion, transform);
                isGrounded = true;
                CancelInvoke();
                Destroy(gameObject, 2);
            }
        }
    
        private void RemoveRocket()
        {
            Destroy(gameObject, 0);
        }
    }
