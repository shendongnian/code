    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            foreach (ContactPoint2D item in col.contacts)
            {
                Debug.Log("Normal:" + item.normal);
                if (item.normal.y > 0 && col.gameObject.tag == "Ground")
                {
                    isJumping = false;
                    Debug.Log("Top of Collider");
                }
            }
        }}
