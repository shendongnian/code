    public static List<Vector3> roadCoordinates = new List<Vector3>();
    
    public static void FindSpawnedRoads()
    {
        loopCount = spawnedObjects.Count;
    
        for (int i = 0; i < loopCount; i++)
        {
            if (spawnedObjects[i].tag == "Road Tag")
            {
                roadCoordinates.Add(new Vector3(spawnedObjects[i].transform.position.x, spawnedObjects[i].transform.position.y, spawnedObjects[i].transform.position.z));
            }
    
        }
    }
