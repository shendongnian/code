    private static readonly Lazy<Controller> _instance;
    private Controller() { }
    public static Controller Instance
    {
        get
        {
            return _instance.Value;
        }
    }
