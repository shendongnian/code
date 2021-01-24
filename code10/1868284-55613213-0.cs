    void Update()
       {
        if (Input.GetKeyDown(KeyCode.Mouse0) && haveGlock == true)
        {
            BulletCollision bc = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
            bc.shoot();
            AudioSource.PlayOneShot(GlockClip);
        }
 
