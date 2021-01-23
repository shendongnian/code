    public static string DoSearch(string query)
    {
        string results = "";
        if (HttpContext.Current.Cache[query] == null)
        {
            results = GetResultsFromSlowDb(query); // HERE
            lock (_cacheLock)
            {
                if (HttpContext.Current.Cache[query] == null)
                {
                    
                    HttpContext.Current.Cache.Add(query, results, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                }
                else
                {
                    results = HttpContext.Current.Cache[query].ToString();
                }
            }
        }
        else
        {
            results = HttpContext.Current.Cache[query].ToString();
        }
