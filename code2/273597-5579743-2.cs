    results = HttpContext.Current.Cache[query];
    if (results == null)         
    {   
        lock(someLock)
        {
            results = HttpContext.Current.Cache[query];
            if (results == null)
            {
                results = GetResultsFromSomewhere();
                HttpContext.Current.Cache.Add(query, results,...);
            }           
        }
    }
    return results;
    
