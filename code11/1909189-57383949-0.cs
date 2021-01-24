    private void OnTriggerEnter(Collider other)
    {
        int tileCacheIndex = other.GetInstanceID();
        Tile tile;
        if (GameManager._instance.tileCache.ContainsKey(tileCacheIndex)) 
        {
            tile = GameManager._instance.tileCache[tileCacheIndex];
        }
        else 
        {
            tile = other.GetComponent<Tile>();
            GameManager._instance.tileCache[tileCacheIndex] = tile;
        }
        if (tile.colorIndex == GameManager.Instance.currentTargetColorIndex)
        {
            Debug.Log("Hit!");
        }
    }
