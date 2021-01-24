    public float powerTime = 0.0f
    private bool poweredUp = false;
    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.tag == "Player")
        {
            powerTime = 10.0f;
        }
    }
    Update()
    { 
        powerTime -= Time.deltaTime;
 
        if (powerTime > 0.0f && !poweredUp)
        {
            poweredUp = true;
            doPowerUp();
        }
        else if (poweredUp)
        {
            doPowerEnd()
        }
    void doPowerUp()
    {
        coli.gameObject.GetComponent<PlayerMove>().jumpForce += jumpTrig;
        coli.gameObject.GetComponent<PlayerMove>().speed += speed;
        coli.gameObject.GetComponent<Health>().health += health;
        
    }
    void doPowerEnd()
    {
        poweredUp = false;
        Destroy(this.gameObject);
    //reset to your normal values.
    }
