    // Code uglified to fit within horizonal scroll area
    public static Dictionary<T2, T1> ReverseDictionary<T1, T2, TEnumerable>(
        this IDictionary<T1, TEnumerable> source) where TEnumerable : IEnumerable<T2>
    {
        return source
            .SelectMany(e => e.Value.Select(s => new { Key = s, Value = e.Key }))
            .ToDictionary(x => x.Key, x => x.Value);
    }
