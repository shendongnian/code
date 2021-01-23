    int totalItemCount = 0;
    foreach (string regionName in cache.GetSystemRegions())
    {
        totalItemCount += cache.GetObjectsInRegion(regionName).Count()
    }
