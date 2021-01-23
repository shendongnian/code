    public static IDictionary<string, string> ToDictionary(this NameValueCollection col)
    {
        IDictionary<string, string> myDictionary = new Dictionary<string, string>();
        if (col != null)
        {
            myDictionary =
                col.Cast<string>()
                    .Select(s => new { Key = s, Value = col[s] })
                    .ToDictionary(p => p.Key, p => p.Value);
        }
        return myDictionary;
    }
