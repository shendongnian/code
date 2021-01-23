    public static IEnumerable<Tuple<string, string>> ToEnumerable(this NameValueCollection collection)
    {
        return collection
          //.Keys
            .Cast<string>()
            .Select(key => new Tuple<string, string>(key, collection[key]));
    }
