    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Long grass")
        {
            col.GetComponent<PlayerMovement>().speed -= 2f;
        }
    }
