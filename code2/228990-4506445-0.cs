    private static Dictionary<Type, Feed> _singletons = new Dictionary<Type, Feed>();
    public static Feed GetFeed<T>() where T:Feed, new()
    {    
        lock(_padlock)
        {
            if (!_singletons.ContainsKey(typeof(T))
            {                   
                _singletons[typeof(T)] = new T();
            }
            return _singletons[typeof(T)];          
        }
    }
