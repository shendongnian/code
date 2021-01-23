    private Dictionary<string,string> _dictionary = new Dictionary<string,string>();
    
    public void AddValue(string key, string value)
    {
        lock (((IDictionary)_dictionary).SyncRoot)    // SyncRoot recommended
        {
           if (!_dictionary.ContainsValue(value))
                _dictionary.Add(key, value);
        }
    }
