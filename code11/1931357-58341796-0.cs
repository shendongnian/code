    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rocks")
        {
            source.Play();
            PlayExplosionAnimation();
            Destroy(gameObject, 0.5);
        }
    }
