    private static Cache Cache;
    public void AddItem(string data)
    {
        //Do a database call to add the data
        //This will force clients to requery the source when GetItems is called again.
        Cache.Remove("test");  
    }
    public List<string> GetItems()
    {
        //Attempt to get the data from cache
        List<string> data = Cache.Get("test") as string;
        //Check to see if we got it from cache
        if (data == null)
        {
            //We didn't get it from cache, so load it from 
            // wherever it comes from.
            data = "From database or something";
            //Put it in cache for the next user
            Cache["test"] = data;
        }
        return data;
    }
