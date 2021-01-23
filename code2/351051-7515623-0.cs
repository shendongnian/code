    public IEnumerable<T> Get<T>(string param1,string param2)
    {
        var result = Get(typeof(T), param1, param2);
        return result.Cast<T>();
    }
