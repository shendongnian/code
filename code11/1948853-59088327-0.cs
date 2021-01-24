    private static void CreateJSONFromDictionary(string[] keys, int index, string value, IDictionary<string, object> dict)
    {
        var key = keys[index];
    
        if (keys.Length > index + 1)
        {
            object childObj;
            IDictionary<string, object> nestedDict;
            if (dict.TryGetValue(key, out childObj))
            {
                nestedDict = (IDictionary<string, object>)childObj;
            }
            else
            {
                nestedDict = new Dictionary<string, object>();
                dict[key] = nestedDict;
            }
    
            CreateJSONFromDictionary(keys, index + 1, value, nestedDict);
    
        }
        else
        {
            dict[key] = value;
        }
    }
