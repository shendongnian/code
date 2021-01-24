    // Would be better even to already reference this via Inspector
    [SerializeField] private Move2D Player;
    private void Awake()
    {
        if(!Player) Player = GetComponentInParent<Move2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Player.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Player.isGrounded = true;
        }
    }
