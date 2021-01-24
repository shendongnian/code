    void OnCollisionEnter2D(Collision2D collision)
    {
            ...
    
            Transform newExplosion = Instantiate(explosion, collision.transform.position,     collision.transform.rotation);
    
    
            // notify other objects that reference "newExplosion.gameObject"
            Destroy(newExplosion.gameObject, 2f);
           
            newExplosion.gameObject = null;
            
    
            gm.UpdateBrickNumber();
    
            // notify other objects that reference "collision.gameObject"
            Destroy(collision.gameObject);
            collision.gameObject = null;
            ...
    }  // void OnCollisionEnter2D(...)
