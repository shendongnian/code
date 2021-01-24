    // Best would be you already reference this via the Inspector
    // Then you can skip the GetComponent completely
    [SerializeField] private PlayerMovement playerMovement;
    private void Awake ()
    {
        // Otherwise get it at runtime and store it for later
        if(! playerMovement) playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        // Now reuse the already stored reference
        facingRight1 = playerMovement.facingRight;
    
        if (Input.GetKeyDown(KeyCode.E) && !holeColliding)
        {
            // Since in both code blocks you do exactly the same
            // .. the only changing is a `-` you can shorten your code a lot
            var x = 0.6f * (facingRight1 ? 1 : -1);
    
            Instantiate(gameObject1, playerPosition.position + new Vector3(x, -1f, 0f), Quaternion.identity);
        }
    
        if (Input.GetKeyDown(KeyCode.F) && holeColliding && !treeColliding)
        {
            Instantiate(gameObject2, holePosition + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
