    public class Move2D : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public bool isGrounded = false;
    
        [SerializeField] private Rigidbody2D rigidbody;
    
        private void Awake()
        {
            if (!rigidbody) rigidbody = GetComponent<Rigidbody2D>();
        }
    
        // this one you simply reference to a normal button
        // or you could also use a continues button to auto jump see below
        public void Jump()
        {
            if (isGrounded) 
            {
                rigidbody.AddForce(new Vector3(0f, 5f), ForceMode2D.Impulse);
            }
        }
        private float movement;
        // this you reference on the left and right button
        public void Move(float value)
        {
            movement = value;
        }
        // AND AGAIN
        // you should always use MovePosition for RIGIDBODIES as I already told you last time
        private void FixedUpdate()
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.right * movement * Time.deltaTime * moveSpeed);
        }
    }
