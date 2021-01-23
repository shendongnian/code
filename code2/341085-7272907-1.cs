    if (HttpContext.Current.Cache["RecycleCheck"] != null)
    { 
        // Add flag to cache
        HttpContext.Current.Cache.Insert("RecycleCheck", "1", null,
            DateTime.UtcNow.AddDays(2),  // 2 days (most will recycle by then)
            System.Web.Caching.Cache.NoSlidingExpiration);
    
        // Do what you need because a recycle has happened
    }
