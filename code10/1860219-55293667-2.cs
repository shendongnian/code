    public PlayerMovement movement;
    public GameObject PowerUp;
    public float jumpUpForce = 5000f;
    public float jumpBackForce = 1000f;
    public Rigidbody rb;
    bool doWeHaveJumpPowerUp;
    Coroutine cor;
    public float timer;
    // 2nd power up
    bool doWeHaveFlyPowerUp;
    
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
        if (collisionInfo.collider.tag == "PowerUpJump")
        {
            PowerUp.SetActive(false);
            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
            cor = StartCoroutine(JumpPower());
        }
        if (collisionInfo.collider.tag == "PowerUpFly")
        {
            PowerUp.SetActive(false);
            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
            cor = StartCoroutine(FlyPower());
        }
    }
    IEnumerator JumpPower()
    {
        doWeHaveJumpPowerUp = true;
        yield return new WaitForSeconds(timer);
        doWeHaveJumpPowerUp = false;
    }
    IEnumerator FlyPower()
    {
        doWeHaveFlyPowerUp = true;
        yield return new WaitForSeconds(timer);
        doWeHaveFlyPowerUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (doWeHaveJumpPowerUp)
            if (transform.position.y < 2)
                if (Input.GetKey("left shift"))
                    rb.AddForce(0, jumpUpForce * Time.deltaTime, -jumpBackForce * Time.deltaTime);
        if (doWeHaveFlyPowerUp)
        {
            //Fly power up logic
        }
    }
