    private static readonly ConcurrentDictionary<string, string> concurrent = 
        new ConcurrentDictionary<string, string>();
    static string InternConcurrent(string s)
    {
        return conc.GetOrAdd(s, s);
    }
    private static readonly Dictionary<string, string> locked = 
        new Dictionary<string, string>(5000);
    static string InternLocked(string s)
    {
        string interned;
        lock (locked)
            if (!locked.TryGetValue(s, out interned))
                interned = locked[s] = s;
        return interned;
    }
