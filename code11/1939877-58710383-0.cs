    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Gem"))
        {
            Destroy(Collision.gameObject);
            money = money + 1;
        }
    }
