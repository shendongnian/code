    private void OnCollisionEnter(Collision collision)
    { 
        // maybe only collide with a certain tag
        if(collision.gameObject.tag != "Target") return;
        //make the explosion
        GameObject ThisExplosion = Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        //destory the projectile
        Destroy(gameObject);
    }
