    private static readonly Lazy<Controller> _instance = new Lazy<Controller>
                                                   (() => new Controller());
    private Controller() { }
    public static Controller Instance
    {
        get
        {
            return _instance.Value;
        }
    }
