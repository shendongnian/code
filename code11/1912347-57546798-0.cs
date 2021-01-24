c#
    public float runSpeed = 2.0f;
    private Rigidbody2D body;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed += 0.5f;
        }
    }
    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        // Up
        if (Input.GetKey(KeyCode.W))
            animator.SetInteger("isWalking", 1);
        // Down
        if (Input.GetKey(KeyCode.S))
            animator.SetInteger("isWalking", 2);
        // Right
        if (Input.GetKey(KeyCode.D))
            animator.SetInteger("isWalking", 3);
        // Left
        if (Input.GetKey(KeyCode.A))
            animator.SetInteger("isWalking", 4);
        if (Input.anyKeyDown == false)
            animator.SetInteger("isWalking", 0);
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
