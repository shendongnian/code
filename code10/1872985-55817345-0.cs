    private ObjectCache cache = MemoryCache.Default;
    public MyServiceDataAccess()
    {
    
    }
    public List<int> GetData()
    {
        string data = cache["someKey"] as List<int>;
        if (data == null)
        {
            //fetch the actual data
            data = GetMyData();
            cache.Set("someKey", data);
        }
        return data
    }
