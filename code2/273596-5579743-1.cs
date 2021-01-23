    results = HttpContext.Current.Cache[query];
    if (HttpContext.Current.Cache[query] == null)         
    {   
        results = GetResultsFromSomewhere();
        HttpContext.Current.Cache.Add(query, results,...);
    }
    return results;
