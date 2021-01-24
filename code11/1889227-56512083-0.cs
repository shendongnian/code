    // It will be triggered the the rocket crashes against the tile
    void OnTriggerEnter2D(Collider2D col)
    {
    	if(collision.gameObject.tag == "rocket")
    	{
    		// Destroy the rocket
    		Destroy(collision.collider.gameObject);
    		// Destroy the Tile
    		Destroy(gameObject);
    	}
    }
