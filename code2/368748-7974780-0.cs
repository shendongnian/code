    public static object GetItem(DateTime dt)
    {
        // Check to see if the cache already has my item
        if (_dictionary.ContainsKey(dt))
            return _dictionary[dt];
    
        lock (_lock)
        {
            // Check the cache AGAIN in case a previous thread inserted our value
            if (_dictionary.ContainsKey(dt))
                return _dictionary[dt];
    
            // Add the generate object to the dictionary
            _dictionary.Add(dt, GenerateMyObject(dt));
        }
    }
    private static Dictionary<DateTime, object> _dictionary = new Dictionary<DateTime, object>();
    private static object _lock = new object();
