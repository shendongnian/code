    public class ShipController : MonoBehaviour
    {
        public Rigidbody rb;
        private float shipVelocity = 5f;
        public float moveSpeed = 10f;
        private Vector3 movement;
       void Update()
       {
            movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            movement.z = Input.GetAxisRaw("Vertical") * moveSpeed + shipVelocity;
       }
        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }
    }
