    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("EnterTagToCompareHere"))
        {
            // Tag on the root object matches
        }
    }
