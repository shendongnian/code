    if(!someSortOfDictionary.ContainsKey(HttpContext.Current.Request.Url))
    {
          someSortOfDictionary.Add(HttpContext.Current.Request.Url, new List<string>());
    }
    
    if(someSortOfDictionary[HttpContext.Current.Request.Url].Count(id => id == someCookieOrSessionId) > 0)
    {
         // Increase hit count!
    }
