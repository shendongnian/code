    void fill()
    {
        // Doing this once at the beginning, so it isn't super expensive...
        GameObject basePrefab = GameObject.Find("Dirt"); 
        // Creating 1 Vector3 that we can just update the values on
        Vector3 spawnPosition = Vector3.zero;
    
        for(int x = 0; x < 1000; ++x)
        {
            // Update the spawn x Position
            spawnPosition.x = x;
            for(int y = 1000; y > 0; y--)
            {
                // Update the spawn y position
                spawnPosition.y = y;
                Instantiate(basePrefab, spawnPosition, Quaternion.identity);
            }
        } 
    }
