    float cursorDepth;
    Rigidbody2d playerRb;
    CircleCollider cc;
    
    void Awake()
    {
       playerRb = GetComponent<Rigidbody2D>();
       cc = GetComponent<CircleCollider>();
    }
    
    private void OnMouseDrag()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        Vector2 posToMouse = mouseInWorld - playerRb.position;
    
        RaycastHit2D hit = Physics2D.CircleCast(playerRb.position, 
                cc.radius * transform.lossyScale.x, posToMouse, posToMouse.magnitude); 
    
        if (hit.collider != null)
        {
            mouseInWorld = hit.centroid;
        }
    
        playerRb.SetPosition(mouseInWorld);
    }
