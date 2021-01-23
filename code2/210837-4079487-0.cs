    var dictionaries = new[] { dict1, dict2, dict3 };
    var result = dictionaries.SelectMany(dict => dict)
                             .GroupBy(o => o.Key)
                             .ToDictionary(g => g.Key,
                                           g => g.Select(o => o.Value).ToArray());
