    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int times)
    {
        source = source.ToArray();
        return Enumerable.Range(0, times).SelectMany(_ => source);
    }
    string indent = "---";
    var f = string.Concat(indent.Repeat(0)); //.NET 4 required
    //or
    var g = new string(indent.Repeat(5).ToArray());
