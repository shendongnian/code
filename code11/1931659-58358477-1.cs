    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Physics usually are done in FixedUpdate to be more constant
    public void FixedUpdate(){
        if (Input.GetKeyDown("space"))
        {
            if(!rb.simulated)
                //player can fall
                rb.simulated = true;
            rb.AddForce(Vector2.up * playerJumpPower);
        }
        else
        {
            //third argument is the distance from the center of the object where it will collide
            //therefore you want the distance from the center to the bottom of the sprite
            //which is half of the player height if the center is acctually in the center of the sprite
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, playerYSize / 2);
            if (hit.collider)
            {
                //make player stop falling
                rb.simulated = false;
            }
        }
    }
