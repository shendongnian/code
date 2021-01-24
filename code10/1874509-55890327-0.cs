    // In your movement class
    public float jumpHeight = 5f; // A public float so we can change its value easily in the inspector
    public static bool isJumping = false; // This bool will tell us if our character is jumping or not
----------
    // Inside the Update method:
    if (Input.GetButtonDown("Jump") && (isJumping == false)) 
    {
       gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }
