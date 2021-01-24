    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("enemy"))
        {
            isDead = true;
            rb2d.velocity = Vector2.zero;
            GameController.Instance.Die();
        }
    }
