    public bool CompareX<TKey, TValue>(
        Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
    {
        var processed = new HashSet<TKey>(dict2.Comparer);
        foreach (KeyValuePair<TKey, TValue> kvp in dict1)
        {
            TValue value2;
            if (!dict2.TryGetValue(kvp.Key, out value2))
                return false;
            if (!kvp.Value.Equals(value2))
                return false;
            processed.Add(kvp.Key);
        }
        return (dict2.Count == processed.Count);
    }
