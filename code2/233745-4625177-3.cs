    public static Dictionary<string, string> ToDictionary(this NameValueCollection collection)
    {
        return collection
          //.Keys
            .Cast<string>()
            .ToDictionary(key => key, key => collection[key]));
    }
