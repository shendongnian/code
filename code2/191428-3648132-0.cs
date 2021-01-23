    public delegate bool TryParser<T>(string text, out T value);
    public static IEnumerable<T> Parse<T>(this IEnumerable<string> source,
                                          TryParser<T> parser)
    {
        source.ThrowIfNull("source");
        parser.ThrowIfNull("parser");
        
        foreach (string str in source)
        {
            T value;
            if (parser(str, out value))
            {
                yield return value;
            }
        }
    }
