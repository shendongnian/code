    var httpCache = HttpContext.Current.Cache;
    var toRemove = httpCache.Cast<DictionaryEntry>()
        .Select(de=>(string)de.Key)
        .Where(key=>key.Contains("subcat"))
        .ToArray(); //use .ToArray() to avoid concurrent modification issues.
    foreach(var keyToRemove in toRemove)
        httpCache.Remove(keyToRemove);
