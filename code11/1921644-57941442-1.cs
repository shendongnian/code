    private static readonly SharedData instance = new SharedData();
    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static SharedData() { }
    private SharedData() { }
    public static SharedData Instance
    {
        get { return instance; }
    }
