    Vector3 position;
    
    void Start()
    {
        if (ScoreScript.scoreValue > 4)
        {
            target = GameObject.Find("White Ball");
            rb = GetComponent<Rigidbody2D>();
            position = target.transform.position;
            moveSpeed = 5f; //Movement speed of all the obstacles and powerups
            InvokeRepeating("MoveInteract", 0f, 1f);
        }
    }
    void MoveInteract() //Method responsable for the movement of the obstacles and stars
    {
        if ( this.gameObject != null)
        {
            directionToTarget = (position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }
