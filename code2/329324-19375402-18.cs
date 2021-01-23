    private static readonly ConcurrentDictionary<string, string> concSafe = 
        new ConcurrentDictionary<string, string>();
    static string InternConcurrentSafe(string s)
    {
        return concSafe.GetOrAdd(s, String.Copy);
    }
