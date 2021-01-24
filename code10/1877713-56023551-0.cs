    float spawnRate = 1f;
    float nextTimeToSpawn = 0;
    
    private void Update()
     {
    
    if (Time.time >= nextTimeToSpawn){
    
    nextTimeToSpawn = Time.time + 1f / spawnRate; }
    
    }
