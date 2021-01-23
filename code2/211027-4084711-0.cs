    static void Compare(SortedDictionary<string, List<foo>> dic1, SortedDictionary<string, List<foo>> dic2)
    {
        var result = new List<List<foo>>();
        var missingkey = new List<List<foo>>();
        foreach (var kvp in dic1)
        {
            var value = default(List<foo>);
            if (dic2.TryGetValue(kvp.Key, out value))
            {
                if (kvp.Value.SequenceEqual(value))
                    result.Add(value);
            }
            else
            {
                missingkey.Add(kvp.Value);
            }
        }
    }
