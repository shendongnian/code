    // Check if the shell hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        col = collision.gameObject;
        if (col.tag == "Player")
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            gameObject.transform.parent = col.transform;
            Debug.Log("Stick!");
        }
    }
