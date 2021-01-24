    void InstantiateChicken()
    {
        List<Vector3> chickenPositions = new List<Vector3>();
        for (int i = 0; i < maxChickenCount; i++)
        {
            bool doesCollide;
            Vector3 spawnLocation;
            do
            {
                spawnLocation = new Vector3(
                    Random.Range(randXMin, randXMax),
                    Random.Range(randYMin, randYMax),
                    5);
                doesCollide = false;
                foreach (var pos in chickPositions)
                {
                    if (Vector2.Distance(pos, spawnLocation) < 2f)
                        doesCollide = true;
                }
            }
            while (doesCollide);
            Instantiate(chickenPrefab1, spawnLocation, Quaternion.identity);
            chickenPositions.Add(spawnLocation);
        }
    }
