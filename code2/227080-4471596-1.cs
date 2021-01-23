    public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max)
    {
        return InSetsOf(source, max, false, default(T));
    }
    public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max, bool fill, T fillValue)
    {
        var toReturn = new List<T>(max);
        foreach (var item in source)
        {
            toReturn.Add(item);
            if (toReturn.Count == max)
            {
                yield return toReturn;
                toReturn = new List<T>(max);
            }
        }
        if (toReturn.Any())
        {
            if (fill)
            {
                toReturn.AddRange(Enumerable.Repeat(fillValue, max-toReturn.Count));
            }
            yield return toReturn;
        }
    }
