    public static class Singleton<T>  where T: new()
    {
    
    static T instance=null;
    static readonly object padlock = new object();
    
    public static T Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance==null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
    
    }
