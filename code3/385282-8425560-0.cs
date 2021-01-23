    delegate int GetNameFromDictionaryCallback(UInt64 key, StringBuilder value);
    public bool GetNameFromDictionary(UInt64 key, StringBuilder value)
    {
        string s;
        if (dict.TryGetValue(key, out s))
        {
            value.Append(s);
            return true;
        }
        return false;
    }
