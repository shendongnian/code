    public int NumberOfRecords()
    {    
    
        System.AppDomain newDomain = null;
    
        try
        {
            newDomain = System.AppDomain.CreateDomain();
            var proxy = newDomain.CreateInstanceAndUnwrap(
                                      typeof(DatabaseProxy).Assembly.FullName,
                                      typeof(DatabaseProxy).FullName);
            return proxy.NumberOfRecords();
        }
        finally
        {
            System.AppDomain.Unload(newDomain);
        }
    }
