    private Collider projectileSpawnParentCollider;
    privtae enum FireType
    {
        One,
        Two
    }
    private void Awake()
    {
      // this hould probably done only once to be more efficient
      projectileSpawnParentCollider = projectileSpawn.parent.GetComponent<Collider>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Fire(FireType.One);
        }
        if (Input.GetButtonDown("Fire2")) 
        {
            Fire(FireType.Two);
        }
    }
    private void Fire(FireType fireType) 
    {
        var position = fireType == FireType.One ? projectileSpawn.position : projectileSpawnTwo.position;
        var rot = projectile.transform.rotation.eulerAngles;
    
        var rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);
        // pass the position and rotation alraedy
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawnParentCollider);
    
        var forceDirection = fireType == FireType.One ? projectileSpawn.forward : (projectileSpawn.position - projectileSpawnTwo.position).normalized;
    
        projectile.GetComponent<Rigidbody>().AddForce(forceDirection * projectileSpeed, ForceMode.Impulse);
    }
    
