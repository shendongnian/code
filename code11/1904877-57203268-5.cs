    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        // Assuming pool.tag euqals obj.tag
        // In general I would rather go by type instead
        poolDictionary[obj.tag].Enqueue(obj);
    }
