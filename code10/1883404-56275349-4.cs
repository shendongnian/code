    private void Fire(FireType fireType) 
    {
        var position = fireType == FireType.One ? projectileSpawn.position : projectileSpawnTwo.position;
        var rot = projectile.transform.rotation.eulerAngles;
    
        var rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);
        // pass the position and rotation alraedy
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawnParentCollider);
    
        if(fireType == FireType.One)
        {
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
        }
        else
        {
            var follow = projectile.AddComponent<FollowPlayer>();
            follow.speed = projectileSpeed;
            follow.PlayerTransform = YourPlayerTransform; // or probably projectileSpawn
        }
    }
