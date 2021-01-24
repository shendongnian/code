    public bool isJumping;
    public float speedUp;
    public float verticalAxis;
    public float jumpLimit;
    public float coolDownTime;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // do nothing is already jumping
        if(isJumping) return;
        
        verticalAxis = Input.GetAxisRaw("Vertical");
        if (verticalAxis > 0)
        {
            // start jumping
            StartCoroutine(Jump());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ground") return;
        
        isGrounded = true;
        StartCoroutine(CoolDown());
    }
    private IEnumerator Jump()
    {
        isJumping = true;
        isGrounded = false;
        coolDownTimer = 0;
        var timePassed = 0f;
        while(timePassed < jumpLimit)
        {
            // wait for the FixedUpdate call
            yield return new WaitForFixedUpdate();
            Vector2 velocity = Vector2.up * speedUp * verticalAxis;
            rb.velocity = velocity;
        }
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeoncds(coolDownTime);
        isJumping = false;
    }
