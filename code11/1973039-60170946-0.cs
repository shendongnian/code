    [SerializeField] Rigidbody2D rb;
    
    privtae void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity.y += acceleration.y * Time.deltaTime;
        Vector3 accelerationRight = Input.GetAxis("Horizontal") * horizontalInputAcceleration * transform.right;
        velocity.x += accelerationRight.x * Time.deltaTime; ;
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
