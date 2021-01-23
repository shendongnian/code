    private static dynamic DictionaryToObject(Dictionary<string, object> dict)
    {
        IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
        foreach (KeyValuePair<string, object> kvp in dict)
        {
            eo.Add(kvp);
        }
        return eo;
    }
