    public void Clear()
    {
       Parallel.ForEach(DataCache.GetSystemRegions(), region =>
       {
          DataCache.ClearRegion(region);
          var sysRegion = DataCache.GetSystemRegionName(region);
          DataCache.ClearRegion(sysRegion);
       });
    }
