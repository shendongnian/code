    public static Dictionary<TValue, TKey> MirrorDictionary<TKey, TValue>
        (Dictionary<TKey, TValue> source)
    {
        Dictionary<TValue, TKey> destination = new Dictionary<TValue, TKey>();
        foreach (KeyValuePair<TKey, TValue> kvp in source)
        {
            destination.Add(kvp.Value, kvp.Key);
        }
        return destination;
    }
