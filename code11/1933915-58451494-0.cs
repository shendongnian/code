    Rigidbody2D rb;<br>
    private void Start(){
       this.rb = circle.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
    //Don't do it here.......
    }
    
    private void OnCollisionEnter2D(Collision collision)
    {
       Vector3 directionToGo = Vector3.Reflect(this.rb.velocity, collision.contacts[0].normal);
    }
