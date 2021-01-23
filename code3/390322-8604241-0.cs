    Response.AddCacheItemDependency("ArcadeChartData" + GameID + Type);
    
    // Set additional properties to enable caching.
    Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
    Response.Cache.SetCacheability(HttpCacheability.Public);
    Response.Cache.SetValidUntilExpires(true);
