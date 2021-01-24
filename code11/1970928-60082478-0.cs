    public float speed;
    public float smoothSpeed; // naming convention for fields is camelCase
    Transform camT;
    Rigidbody rb;
    Quaternion rot;
    private Vector3 vel = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        camT = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        rb.velocity = (transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed) + (transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed) + (transform.up * rb.velocity.y);
    
        if(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude > 0)
        {
            rot = Quaternion.Euler(0f,camT.eulerAngles.y,0f);
        }
    
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * smoothSpeed);
    
    }
