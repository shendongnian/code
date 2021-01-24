    public float thrust; //set in editor, this is how strong you will be pushing the object 
    private Rigidbody2D rb;
    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * thrust); //this will move your RB to the right while you hold the right arrow
        }
    }
