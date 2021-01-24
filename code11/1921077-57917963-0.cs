    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider2D>().tag == "Ground")
        {
            Player.GetComponent<Move2D>().isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Player.GetComponent<Move2D>().isGrounded = true;
        }
    }
