    private List<GameObject> currentlySpawnedObjects = new List<GameObject>();
    //...
        GameObject obj = Instantiate(pool.prefab);
        currentlySpawnedObjects.Add(obj);
    //...
    public void Release(GameObject obj)
    {
        currentlySpawnedObjects.Remove(obj);
        obj.SetActive(false);
        obj.SetParent(transform);
        // Assuming pool.tag euqals obj.tag
        // In general I would rather go by type instead
        poolDictionary[obj.tag].Enqueue(obj);
    }
    //...
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach(var child in currentlySpwnedObjects)
        {
            Release(child);
        }
    }
