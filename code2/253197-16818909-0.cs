    public static IEnumerable<T> MostFrequent<T>(this IEnumerable<T> input)
    {
        var dict = input.ToLookup(x => x);
        if (dict.Count == 0)
            return Enumerable.Empty<T>();
        var maxCount = dict.Max(x => x.Count());
        return dict.Where(x => x.Count() == maxCount).Select(x => x.Key);
    }
    var most = "".MostFrequent().ToArray(); //empty collection returned
    var most = "abc".MostFrequent().ToArray(); //{ a, b, c } returned
    var most = "aabc".MostFrequent().ToArray(); //{ a } returned
    var most = "aabbc".MostFrequent().ToArray(); //{ a, b }returned
