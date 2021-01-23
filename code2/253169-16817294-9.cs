    public static IEnumerable<T> Mode<T>(
        this IEnumerable<T> source,
        IEqualityComparer<T> comparer = null)
    {
        var counts = new Dictionary<T, int>(comparer);
        var max = 1;
        foreach (var t in source)
        {
            if (counts.ContainsKey(t))
            {
                var newCount = ++counts[t];
                if (newCount > max)
                {
                   max++;
                }
                continue;
            }
            counts.Add(t, 1)
        }
        foreach (var count in counts)
        {
            if (count.Value == max)
            {
                yield return count.Key;
            }
        }
    }
