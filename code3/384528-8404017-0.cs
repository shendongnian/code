    public void Reload(IDictionary<TKey, TValue> values)
    {
        cache = new Dictionary<TKey, TValue> ();
        foreach (KeyValuePair<TKey, TValue> value in values)
        {
            cache[value.Key] = value.Value;
        }
        lock (_syncLock)
        {
            _internalCache = cache;
        }
    }
