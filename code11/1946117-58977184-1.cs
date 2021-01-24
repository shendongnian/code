    // cache the connection string
    HttpContextCache cache = new HttpContextCache();
    cache.Store("WEBConnectionString", ConfigurationManager.ConnectionStrings["WEBConnectionString"].ConnectionString);
    // ...
    
    // get connection string from the cache
    HttpContextCache cache = new HttpContextCache();
    string conString = cache.Retrieve<string>("WEBConnectionString");
