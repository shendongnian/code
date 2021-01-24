    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.parent.CompareTag("Enemy"))
        {
            //Do stuff
        }
    }
