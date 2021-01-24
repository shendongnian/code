    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet1")
        {
            hp1 -= damage1;
            Destroy(col.gameobject); 
        }
    }
