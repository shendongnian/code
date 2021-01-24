    private bool facingRight;
         
        private void Start()
        {
            bar = GameObject.Find("minibar");
            bed = GameObject.Find("bed");
    
            rb = GetComponent<Rigidbody2D>();
        }
    
        private void Update()
        {
            RaycastHit2D hitObject = Physics2D.Raycast(rayOriginPoint.position,rayDir,range);
            Debug.DrawRay(rayOriginPoint.position,rayDir*range);
    
            if(hitObject == true) {
                if(hitObject.collider.name == bed.name) {
                    Debug.Log(hitObject.collider.name);
                    rayDir *= -1;
                    facingRight = true;
                    Flip();
                }
                if(hitObject.collider.name == bar.name) {
                    Debug.Log(hitObject.collider.name);
                    rayDir *= -1;
                    facingRight = false;
                    Flip();
                }
            }
        }
    
        protected override void Move()
        {
            // rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            base.Move();
            if(facingRight == false) {
                rb.velocity = new Vector2(-1, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(1,rb.velocity.y);
            }
        }
