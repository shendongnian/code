    [SerializeField] private Rigidbody2D rigidbody;
    private void Awake()
    {
        if(!rigidbody) rigidbody = GetComppnent<Rigidbody2D>();
    }
    void Jump()
    {
        // This is very small but it is slightly cheaper to check the 
        // isGrounded value so this order is minimal faster if isGrounded is false
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(new Vector3(0f, 5f), ForceMode2D.Impulse);
        }
    }
