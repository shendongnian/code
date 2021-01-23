    //Don't want to declare the key as type K because I assume _inner will be a Dictionary<string, V>
    //public void Add(K key, V value)
    //
    public void Add(string key, V value)
    {
        try
        {
            _inner.Add(key, value);
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Exception adding key '" + key + "'", e);
        }
    }
