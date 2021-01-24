    public static bool IsAvailable { get; set; } = false;
    private static List<string> _available;
    public static List<string> Available
    {
        get
        {
            if (IsAvailable)
                return _available;
            else
                return null;
        }
        set { _available = value; }
    }
