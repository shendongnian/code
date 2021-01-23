    public void Initialize(IEnumerable<Type> types)
    {
        foreach(var type in types)
        {
            var list = Activator.CreateInstance(Type.GetType("System.Collections.Generic.List`1").MakeGenericType(type));
            _cache[type] = list;
        }
    }
    public ICollection<T> Get<T>()
    {
        object list;
        if (_cache.TryGetValue(typeof(T), out list)
        {
           return list as ICollection<T>;
        }
        else
        {
           ...
        }
    }
    var cats = Get<Cat>();
