    public static IEnumerable<IEnumerable<TSource>> BatchForward<TSource>(
        this IEnumerable<TSource> source, int size)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        var counter = 0;
        var batchVersion = 0;
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                counter++;
                batchVersion++;
                if ((counter - 1) % size == 0)
                    yield return GetInnerEnumerable(enumerator, batchVersion);
            }
            batchVersion++;
        }
        IEnumerable<TSource> GetInnerEnumerable(IEnumerator<TSource> enumerator, int version)
        {
            while (true)
            {
                if (version != batchVersion)
                    throw new InvalidOperationException("Enumeration out of order.");
                yield return enumerator.Current;
                if (counter % size == 0) break;
                if (!enumerator.MoveNext()) break;
                counter++;
            };
        }
    }
