    public void Insert(GameObject target)
    {
        if (projectile) return;
        Ray centerRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0f));
        projectile = Instantiate(projectileInsert, transform.position, Quaternion.identity);
        ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();
        projectileScript.SetTarget(centerRay, collisionLayers);
        projectileScript.speed = projectileSpeed;
        // Physics.IgnoreCollision(projectile.GetComponent<Collider>(),
        // projectileSpawn.parent.GetComponent<Collider>()); 
    }
    public void Extract(GameObject target)
    {
        if (projectile) return;
        projectile = Instantiate(projectileExtract, target.transform.position, Quaternion.identity);
        ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();
        projectileScript.SetTarget(gameObject);
        projectileScript.speed = projectileSpeed;
        // Physics.IgnoreCollision(projectile.GetComponent<Collider>(),
        // projectileSpawn.parent.GetComponent<Collider>()); 
    }
