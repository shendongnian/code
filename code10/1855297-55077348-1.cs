     [SerializeField]
    public HUD hud;
    [SerializeField]
    public GameObject prefabBullet;
    Bullet script;
   
    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
          hud = GetComponent<HUD>();
      //  bullet = prefabBullet.GetComponent<Bullet>();
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        //Firing the Bullet
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           
           GameObject bullet =  Instantiate(prefabBullet, transform.position, Quaternion.identity) ;
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            
            AudioManager.Play(AudioClipName.PlayerShot);
        }
        
        
    }
    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustDirection,ForceMode2D.Force);
        }
    }
    /// <summary>
    /// Destroys the ship on collision with an asteroid
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        hud = GameObject.Find("HUD").GetComponent<HUD>();
        
        AudioManager.Play(AudioClipName.PlayerDeath);
        if (coll.gameObject.CompareTag("Asteroid"))
        {
            hud.StopGameTimer();
            gameObject.SetActive(false);
           // Destroy(gameObject);
            
        }
    }
