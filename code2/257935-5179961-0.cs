    public sealed class Singleton<T>
    {
    static T instance=null;
    static readonly object padlock = new object();
    static Func<T> createInstance;
    
    Singleton(Func<T> constructor)
    {
       createInstance = constructor;
    }
    
    public static T Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance==null)
                {
                    instance = createInstance();
                }
                return instance;
            }
        }
    }
    }
