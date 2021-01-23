    public static NameValueCollection ToNameValueCollection<TKey, TValue>(
        this IDictionary<TKey, TValue> dict)
    {
        var nameValueCollection = new NameValueCollection();
        foreach(var kvp in dict)
        {
            nameValueCollection.Add(kvp.Key.ToString(), kvp.Value.ToString());
        }
        return nameValueCollection;
    }
