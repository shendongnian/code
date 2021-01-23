    private static readonly Dictionary<string, string> _dict = new Dictionary<string, string>();
    public static string GetSomething(string key)
    {
        string result;
        lock (_dict)
        {
            if (!_dict.TryGetValue(key, out result))
            {
                _dict[key] = result = CalculateSomethingExpensive(key);
            }
        }
        return result;
    }
