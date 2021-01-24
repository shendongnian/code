    IEnumerator Start()
    {
        r = GetComponent<Renderer>();
        for (int i = 0; i < spawnerData.spawnableObjects.Length; i++)
        {
            spawnerData.spawnableObjects[i].currentObjects = 0;
        }
        spawnerData.SpawnedObjects.Clear();
    
        // wait until Physics are initialized
        yield return new WaitForFixedUpdate();
        SpawnObjects();
    }
