    public static string ToPrettyString<TKey, TValue>(this IDictionary<TKey, TValue> dict)
    {
        var str = new StringBuilder();
        str.Append("{");
        foreach (var pair in dict)
        {
            str.Append(String.Format(" {0}={1} ", pair.Key, pair.Value));
        }
        str.Append("}");
        return str.ToString();
    }
    
