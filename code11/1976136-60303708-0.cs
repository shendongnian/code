    public int maxJumps = 2;
    private int jumps;
    private float jumpForce = 5f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            this.Jump ();
        }
    }
    private void Jump()
    {
        if (jumps > 0)
        {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForcMode2D.Impulse);
            grounded = false;
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            jumps = maxJumps;
            grounded = true;
            movespeed = 2.0F;                                                            
         }                                                                                
     }
