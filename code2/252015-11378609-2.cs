    public static IEnumerable<IEnumerable<T>> Transpose<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        return source
            .Select(a => a.Select(b => Enumerable.Repeat(b, 1)))
            .DefaultIfEmpty(Enumerable.Empty<IEnumerable<T>>())
            .Aggregate(Zip);
    }
    public static IEnumerable<IEnumerable<T>> Zip<T>(
        IEnumerable<IEnumerable<T>> first, 
        IEnumerable<IEnumerable<T>> second)
    {
        var firstEnum = first.GetEnumerator();
        var secondEnum = second.GetEnumerator();
        while (firstEnum.MoveNext())
            yield return ZipHelper(firstEnum.Current, secondEnum);
    }
    private static IEnumerable<T> ZipHelper<T>(
        IEnumerable<T> firstEnumValue, 
        IEnumerator<IEnumerable<T>> secondEnum)
    {
        foreach (var item in firstEnumValue)
            yield return item;
        secondEnum.MoveNext();
        foreach (var item in secondEnum.Current)
            yield return item;
    }
