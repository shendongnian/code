    public static string _test;
    public static string _setting;
    
    public static string Test_1
    {
        get { return _test ?? (_setting ?? "default"); }
    }
