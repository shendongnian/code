    public static IDictionary<string, string> ToDictionary(this NameValueCollection col)
    {
        IDictionary<string, string> myDictionary =
            col.Cast<string>()
            .Select(s => new { Key = s, Value = col[s] })
            .ToDictionary(p => p.Key, p => p.Value);
        return myDictionary;
    }
