    private static Dictionary<Type, Feed> _singletons = new Dictionary<Type, Feed>();
    public static Feed GetFeed<T>() where T:Feed
    {    
        lock(_padlock)
        {
            if (!_singletons.ContainsKey(typeof(T))
            {                   
                return typeof(T).GetMethod("GetInstance", System.Reflection.BindingFlags.Static).Invoke(null,null);
            }
            return _singletons[typeof(T)];          
        }
    }
