    // already reference the component via the Inspector
    [SerializeField] Rigidbody2D rb;
    
    Vector3 acceleration;
    Vector3 accelerationRight;
    privtae void Awake()
    {
        if(!rb) rb = GetComponent<Rigidbody2D>();
    }
    
    // Get user input within Update
    private void Update()
    {
        acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        accelerationRight = Input.GetAxis("Horizontal") * horizontalInputAcceleration * transform.right;
    }
    
    // update the Rigidbody in FixedUpdate
    private void FixedUpdate()
    {
        velocity = rb.velocity;
        // do these here so Time.deltaTime uses the correct value
        velocity += acceleration * Time.deltaTime;
        velocity += accelerationRight * Time.deltaTime;
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // Problem: MovePosition expects a value in global world space
        // so if your velocity is in local space 
        // - which seems to be the case  - you will have to convert 
        // it into a global position first
        var newPosition = rb.position + transform.TransformDirection(velocity  * Time.deltaTime);
        rb.MovePosition(newPosition);
    }
