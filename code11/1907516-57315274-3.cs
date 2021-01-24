    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>() == null)
            return;
        health = other.GetComponent<Health>();
        if (health.TakeHeal(healthBonus))
        { 
            Destroy(gameObject); 
        }
    }
