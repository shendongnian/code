    public static TValue AddIfNotExists<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        where TValue : new()
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            value = new T();
            dict.Add(key, value);
        }
        return value;
    }
