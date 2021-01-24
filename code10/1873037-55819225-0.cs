    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "coin")
        {
            Destroy(collision.gameObject);
            enemyBehavior script = enemy.GetComponent<enemyBehavior>();
            script.evade = false;
        }
    }
