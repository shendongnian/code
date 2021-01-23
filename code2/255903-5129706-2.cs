    /// <summary>
    /// Returns an enumeration of tuples containing all unique pairs of distinct
    /// elements from the source collection. For example, the input sequence
    /// { 1, 2, 3 } yields the pairs [1,2], [1,3] and [2,3] only.
    /// </summary>
    public static IEnumerable<Tuple<T, T>> UniquePairs<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return uniquePairsIterator(source);
    }
    private static IEnumerable<Tuple<T, T>> uniquePairsIterator<T>(IEnumerable<T> source)
    {
        // Make sure that 'source' is evaluated only once
        IList<T> arr = source as IList<T> ?? source.ToList();
        for (int i = 0; i < arr.Count - 1; i++)
            for (int j = i + 1; j < arr.Count; j++)
                yield return new Tuple<T, T>(arr[i], arr[j]);
    }
