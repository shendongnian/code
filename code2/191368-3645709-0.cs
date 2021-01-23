    /// <summary>Sorts the elements of a sequence in ascending order.</summary>
    public static IEnumerable<T> Order<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(x => x);
    }
