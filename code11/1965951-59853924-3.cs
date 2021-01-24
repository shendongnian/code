    private static readonly object LockObject = new object();
    private static MyClass _instance;
    public static MyClass Instance
    {
        get
        {
            lock (LockObject)
            {
                return _instance ?? (_instance = new MyClass());
            }
        }
    }
