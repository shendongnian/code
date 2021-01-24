    // Reference it via the inspector
    // This will store the reference to the PlayerMovement Component instance
    [SerializeField] private PlayerMovement playerMovement;
    private void Awake ()
    {
        // Or get it on runtime
        if(!playerMovement) playerMovement = GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // I also strongly recommend using CompareTag
        // It is slightly faster and additionally throws an error
        // if an invalid tag is passed -> more secure and better to debug
        if (col.gameObject.CompareTag("Long grass")
        {
            playerMovement.speed -= 2f;
        }
    }
