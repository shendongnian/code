    public static string GetValue(string key)
    {
        if(Global.dictionary.ContainsKey(key))
        {
            return Global.dictionary[key];
        }
    
        return ""; // or some other value
    }
