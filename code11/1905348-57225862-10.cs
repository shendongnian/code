        Public Bool isMoving;
        
        void Shoot()
        {
            //I'm assuming you also dont want muzzleflash to play.
          if (isMoving != true)
           {
             MuzzleFlash.Play();    
        
              RaycastHit hit;
              if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
            {
               
     Debug.Log(hit.transform.name);
        
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }
        
            }
