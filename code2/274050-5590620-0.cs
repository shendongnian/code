    Dictionary<string, double> dictionary = new Dictionary<string, double>();
    dictionary.Add("Foo", 1.2);
    dictionary.Add("Bar", 2.4);
    
    foreach (KeyValuePair<string, double> pair in dictionary)
    {
        // work with pair.Key and pair.Value, each strongly typed
    }
