    private static readonly object mutex = new object();
    // Or whatever
    private static readonly Dictionary<string, string> map =
        new Dictionary<string, string>();
    public static void AddEntry(string key, string value)
    {
        lock (mutex)
        {
            map[key] = value;
        }
    }
    public static void GetValue(string key, string value)
    {
        lock (mutex)
        {
            return map[key];
        }
    }
