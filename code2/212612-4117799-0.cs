    [WebMethod]
    public string Method1()
    {
        SomeObj so = TryGetFromCacheOrStore<SomeObj>(() => SomeClass.GetSomeObj(), "so");
        return so.Method1(); //this exetus in a moment 
    }
    [WebMethod]
    public string Method2()
    {
        SomeObj so = TryGetFromCacheOrStore<SomeObj>(() => SomeClass.GetSomeObj(), "so");
        return so.Method2(); //this exetus in a moment 
    }
    private T TryGetFromCacheOrStore<T>(Func<T> action, string id)
    {
        var cache = Context.Cache;
        T result = (T)cache[id];
        if (result == null)
        {
            result = action();
            cache[id] = result;
        }
        return result;
    }
