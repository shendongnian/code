    private List<GameObject> currentlySpawnedObjects = new List<GameObject>();
    //...
    public void Release(GameObject obj)
    {
        currentlySpawnedObjects.Remove(obj);
        obj.SetActive(false);
        // here you should still make it a child so it doesn't get destroyed
        // when the scene is changed
        obj.SetParent(transform);
        // Assuming pool.tag euqals obj.tag
        // In general I would rather go by type instead
        poolDictionary[obj.tag].Enqueue(obj);
    }
    //...
    // call this BEFORE switching scenes
    public void ReleaseAll()
    {
        foreach(var child in currentlySpawnedObjects)
        {
            Release(child);
        }
    }
