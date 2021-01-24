    var ids = new ConcurrentBag<string>();
    // List contains lets say 10 ID's 
    var apiKey = ctx.ApiKey.FirstOrDefault();
    var expired = false;
    
    Parallel.ForEach(ids, id => 
    {
        try
        {
            // Perform API calls
        }
        catch (Exception ex)
        {
            if (ex.Message == "Expired")
            {
               expired = true;
            }
        }
    }
    
    if (expired)
    {
       // the idea is that if that only one thread can access the DB record to 
       // update it, not multiple ones
       using (var ctx = new MyEntities())
       {
         var findApi= ctx.ApiKeys.Find(apiKey.RecordId);
         findApi.Expired = DateTime.Now.AddHours(1);
         findApi.FailedCalls += 1;
        }
    });
