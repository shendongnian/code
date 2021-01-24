    private float chubbyScore = 0;
    private float coin = 0;
    public float speed = 1;
    public float jump = 1;
    public float offsetTime = 2f;
    private float timer = 0f;
    private GameObject collObj;
    void Update()
    {
        Vector3 playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxis("Horizontal");
        transform.position += playerMovement * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jump;
        }
        if(!collObj.active)
        {
            timer += Time.deltaTime;
            if(timer > offsetTime)
            {
                timer = 0f;
                collObj.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            collObj = other.gameObject;
            collObj.SetActive(false);
            coin += 1;
            chubbyScore += 50;
        }
    }
