    public string DictToString(Dictionary<string, string> dict)
    {
        string toString = "";
        foreach (string key in dict.Keys)
        {
                toString += key + "=" + dict[key];
        }
        return toString;
    }
