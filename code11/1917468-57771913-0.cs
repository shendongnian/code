    // Would be even beter if you already reference these in the Inspector
    [SerializeField] private Rigidbody graphics;
    [SerializeField] private ExclamationMarkSpawn exclamationMark;
    [SerializeField] private Transform player;
    private void Awake()
    {
        if(!player) player = GameObject.FindWithTag("Player");
        if(!graphics) graphics = GetComponentInChildren<Rigidbody>(true);
        if(!exclamationMark) exclamationMark = GetComponentInChildren<ExclamationMarkSpawn>(true);
    }
    private void CheckForPlayer()
    {
        // If really needed you can also after Awake still use a lazy initialization
        // this adds a few later maybe unnecessary if checks but is still 
        // cheaper then using Find over and over again
        if(!player) player = FindWithTag("Player");
        if(!graphics) graphics = GetComponentInChildren<Rigidbody>(true);
        if(!exclamationMark) exclamationMark = GetComponentInChildren<ExclamationMarkSpawn>(true);
        var playerPos = (int)player.position.x;
    
        // always if making such a check also give a hint that something might be missing
        if (!graphics)
        {
            // by adding "this" you can now simply click on the message
            // in the console and it highlights the object where this is happening in the hierarchy
            Debug.LogWarning("graphics is missing here :'( ", this);
            return;
        }
        
        // Define gameobject position
        var enemyPos = graphics.transform.position.x;
    
        // Define range to spawn tiles in
        // this entire block can be shrinked down to
        if (Mathf.Abs(playerPos - enemyPos) <= 5)
        {
            enemyIsActive = true;
    
            if (exclamationMark) exclamationMark.SpawnExclamationMark();
        }
        else
        {
            enemyIsActive = false;
        }
    }
    
