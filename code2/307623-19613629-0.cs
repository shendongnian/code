    public void Clear()
    {
       Parallel.ForEach(DataCache.GetSystemRegions(), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, region =>
       {
          DataCache.ClearRegion(region);
       });
    }
