    public PlayerMovement movement;
    public GameObject PowerUp;
    public float jumpUpForce = 5000f;
    public float jumpBackForce = 1000f;
    public Rigidbody rb;
    bool doWeHaveJumpPowerUp;
    Coroutine cor;
    public float timer;
	// Use this for initialization
	void Start()
    {
        doWeHaveJumpPowerUp = false;
        timer = 10.0f;
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
            movement.enabled = false;
        if (collisionInfo.collider.tag == "PowerUp")
        {
            PowerUp.SetActive(false);
            if(cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
            cor = StartCoroutine(JumpPower());
        }
    }
    IEnumerator JumpPower()
    {
        doWeHaveJumpPowerUp = true;
        yield return new WaitForSeconds(timer);
        doWeHaveJumpPowerUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (doWeHaveJumpPowerUp)
            if (transform.position.y < 2)
                if (Input.GetKey("left shift"))
                    rb.AddForce(0, jumpUpForce * Time.deltaTime, -jumpBackForce * Time.deltaTime);
    }
