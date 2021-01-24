    public void OnStartShooting()
    {
        for (int i = 0; i < numToShoot; i++)
        {
            var projectile = Instantiate(projectileObject);
            projectile.transform.position = projectileEmitter.position;
            var projectileScript = projectile.GetComponent<Projectile>();
            float anglePercentage;
            if (numToShoot == 1)
                anglePercentage = 0f;
            else
                anglePercentage = (float)i/(numToShoot-1f) - .5f;
            projectileScript.moveDirection = DirFromAngle(
                      coneDirection 
                    + anglePercentage * angle, rayRange);
            projectile.SetActive(true);
        }
    }
