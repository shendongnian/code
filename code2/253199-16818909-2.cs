    public static IEnumerable<T> Mode<T>(this IEnumerable<T> input)
    {
        var dict = input.ToLookup(x => x);
        if (dict.Count == 0)
            return Enumerable.Empty<T>();
        var maxCount = dict.Max(x => x.Count());
        return dict.Where(x => x.Count() == maxCount).Select(x => x.Key);
    }
    var modes = "".Mode().ToArray(); //returns { }
    var modes = "abc".Mode().ToArray(); //returns { a, b, c }
    var modes = "aabc".Mode().ToArray(); //returns { a }
    var modes = "aabbc".Mode().ToArray(); //returns { a, b }
