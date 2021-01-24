    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))) 
        {
            //player takes damage!
            player = other.gameObject;
    
            player.GetComponent<yourscriptname>().health -= damage;
        
            Debug.Log(player.GetComponent<yourscriptname>().health);
        
            Destroy(player);
        }
