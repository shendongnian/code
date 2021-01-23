    public static string DoSearch(string query)
    {
        var results = (string)HttpContext.Current.Cache[query];
        if (results == null)
        {
            results = GetResultsFromSlowDb(query);
            HttpContext.Current.Cache.Insert(query, results, null,
                DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
        }
        return results;
    }
