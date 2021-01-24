    void OnCollisionEnter(Collision other)
    {
         if (isHoming) 
         {
             return;
         }
         if( && ((1<<other.gameObject.layer) & collisionLayers) != 0)
         {
             //make the explosion
            GameObject ThisExplosion = Instantiate(Explosion, 
                    gameObject.transform.position, 
                    gameObject.transform.rotation) as GameObject;
            //destroy the projectile
            Destroy(gameObject);
         }
    }
