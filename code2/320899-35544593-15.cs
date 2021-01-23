    var d1 = new Dictionary<string, string>();
    var d2 = new Dictionary<string, string>();
    d1.Add("key1", "dog");
    d2.Add("key1", "Dog");
    d1.Add("key2", "CAT");
    d2.Add("key2", "cat");
    bool isEqual = DictionaryEqual(d1, d2,
        (s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase));
