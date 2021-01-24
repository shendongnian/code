    private Rigidbody2D rb2d;
    private float h = 0.0f;
    public float Speed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    float fireElapsedTime = 0;
    public float fireDelay = 0.2f;
    
    
        // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    
    }
    
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h != 0.0f)
        {
            rb2d.velocity = new Vector2(h * Speed, rb2d.velocity.y);
        }
        if (h == 0.0f)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    
        }
        fireElapsedTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            Shoot();
        }
    }
    
    
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
