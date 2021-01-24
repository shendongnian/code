    private Rigidbody2D rb2d;   
    private Transform t;
    private float h = 0.0f;
    public float Speed, Jump;
    private bool canJump;
    private Animator anim;
    private BoxCollider2D bc2d;
    // Variable to check if character is attempting to stand
    private bool tryingToStand = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        t = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        transform.Translate(Vector3.right * h * Speed * Time.deltaTime);
        if (h != 0.0f)
        {
            transform.localScale = new Vector2(h, transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, Jump));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bc2d.enabled = false;
            Speed = Speed / 2;
            anim.SetBool("Crouch", true);
            // Set tryingToStand to false in case player holds ctrl again before character has stood up
            tryingToStand = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            tryingToStand = true;            
        }
        if (tryingToStand && CanStand())
        {
            tryingToStand = false;
            bc2d.enabled = true;
            Speed = Speed * 2;
            anim.SetBool("Crouch", false);
        }
    }
    bool CanStand()
    {        
        RaycastHit2D hit = Physics2D.Raycast(t.position, Vector2.up);
        if (hit.collider != null)
        {
            // Check the distance to make sure the character has clearance, you'll have to change the 1.0f to what makes sense in your situation.
            if (hit.distance <= 1.0f)
            {
                return false;
            }
        }
        return true;    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            canJump = true;
            anim.SetBool("Jump", false);
        }    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            canJump = false;
            anim.SetBool("Jump", true);
        }
    }
