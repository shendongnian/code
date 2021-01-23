    public string DictToString<TKey, TValue>(Dictionary<TKey, TValue> items, string format)
    {
        format = String.IsNullOrEmpty(format) ? "{0}='{1}' " : format;
        return items.Aggregate(new StringBuilder(), (sb, kvp) => sb.AppendFormat(format, kvp.Key, kvp.Value)).ToString();
    }
