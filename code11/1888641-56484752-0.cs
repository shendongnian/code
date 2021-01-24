    private Collider2D playerCollider; 
    private float playerJumpableOffset = 0.001;
    void Start() { playerCollider = GetComponent<Collider2D>(); }
    void OnCollisionEnter2D(Collision2D col)
    {
        float jumpableWorldHeight = transform.position - playerJumpableOffset;
        Vector2 contactPoint = col.GetContact(0).point; 
        if (col.gameObject.tag == "Ground" &&
                contactPoint.y <= jumpableWorldHeight )
        {
            isJumping = false;
        }        
    }
