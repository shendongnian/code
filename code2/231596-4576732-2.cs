    public static bool UnsortedSequencesEqual<T>(
        this IEnumerable<T> first,
        IEnumerable<T> second)
    {
        return UnsortedSequencesEqual(first, second, null);
    }
    public static bool UnsortedSequencesEqual<T>(
        this IEnumerable<T> first,
        IEnumerable<T> second,
        IEqualityComparer<T> comparer)
    {
        if (first == null)
            throw new ArgumentNullException("first");
        if (second == null)
            throw new ArgumentNullException("second");
        var counts = new Dictionary<T, int>(comparer);
        foreach (var i in first) {
            int c;
            if (counts.TryGetValue(i, out c))
                counts[i] = c + 1;
            else
                counts[i] = 1;
        }
        foreach (var i in second) {
            int c;
            if (!counts.TryGetValue(i, out c))
                return false;
            if (c == 1)
                counts.Remove(i);
            else
                counts[i] = c - 1;
        }
        return counts.Count == 0;
    }
