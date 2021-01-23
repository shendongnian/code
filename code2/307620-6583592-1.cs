    /* Assumes DataCache as a properly set up Microsoft.ApplicationServer.Caching.Client.DataCache object */
    public void Clear()
    {
       Parallel.ForEach(DataCache.GetSystemRegions(), region =>
       {
          DataCache.ClearRegion(region);
          var sysRegion = DataCache.GetSystemRegionName(region);
          DataCache.ClearRegion(sysRegion);
       });
    }
