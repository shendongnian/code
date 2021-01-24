    private Dictionary<string, Pool> prefabPools;
    private void Start()
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            prefabPools.Add(pool.tag, pool);
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn;
        // check if there are objects left otherwise insteantiate a new one
        if(poolDictionary[tag].Count > 0)
        {
            objectToSpawn = poolDictionary[tag].Dequeue();
        }
        else
        {
            objectToSpawn = Instantiate(prefabPools[tag].prefab);
        }
        if(parent)
        {
            objectToSpawn.SetParent(parent, false);
        }
         
        // you could also decide to use localPosition in case parent is set
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        objectToSpawn.SetActive(true);
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        currentlySpawnedObjects.Add(objectToSpawn);
        return objectToSpawn;
    }
