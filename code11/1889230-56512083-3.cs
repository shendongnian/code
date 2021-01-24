    // It will be triggered the the rocket crashes against the tile
    void OnTriggerEnter2D(Collider2D col)
    {
    	if(collision.gameObject.tag == "tile")
    	{
    		// Destroy the tile the rockets collided with
    		Destroy(collision.collider.gameObject);
    		// Destroy the rocket itself
    		Destroy(gameObject);
    	}
    }
