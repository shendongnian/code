    public SpriteRenderer render;
    void Start()
    {
        render.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            render.enabled = true;
        }
    }
