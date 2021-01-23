    static void Compare(SortedDictionary<string, List<foo>> dic1, SortedDictionary<string, List<foo>> dic2)
    {
        const string isIgnored = null, isResult = "result", isMissingkey = "missingkey";
        var combined = (from kvp in dic1
                        group kvp.Value by (dic2.ContainsKey(kvp.Key)
                                                ? kvp.Value.SequenceEqual(dic2[kvp.Key])
                                                      ? isResult
                                                      : isIgnored
                                                : isMissingkey) into g
                        where g.Key != isIgnored
                        select g)
                       .ToDictionary(g => g.Key, g => g.ToList());
        // result in combined["result"]
        // missingkey in combined["missingkey"]
    }
