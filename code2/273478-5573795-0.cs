    public void Add(K key, V value)
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
