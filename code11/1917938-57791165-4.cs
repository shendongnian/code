    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime));
        ...
    }
