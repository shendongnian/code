    private static dynamic DictionaryToObject(Dictionary<string, object> dict)
    {
        IDictionary<string, object> eo = (IDictionary<string, object>)new ExpandoObject();
        foreach (KeyValuePair<string, object> kvp in dict)
        {
            eo.Add(kvp);
        }
        return eo;
    }
