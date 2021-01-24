    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Present"))
        {
            Destroy(other.gameObject);
            count = count - 1;
            SetCountText();
        }
    }
