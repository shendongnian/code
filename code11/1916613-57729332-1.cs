    // Check if the shell hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        col = collision.gameObject;
        if (col.tag == "Player")
        {
            rb.isKinematic = true;
            gameObject.transform.parent = col.transform;
            Debug.Log("Stick!");
        }
    }
