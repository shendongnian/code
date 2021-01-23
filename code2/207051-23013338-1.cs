    public static IEnumerable<IEnumerable<T>> JaggedPivot<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var originalEnumerators = source.Select(x => x.GetEnumerator()).ToList();
        try
        {
            var enumerators =
                new List<IEnumerator<T>>(originalEnumerators.Where(x => x.MoveNext()));
            while (enumerators.Any())
            {
                yield return enumerators.Select(x => x.Current).ToList();
                enumerators.RemoveAll(x => !x.MoveNext());
            }
        }
        finally
        {
            originalEnumerators.ForEach(x => x.Dispose());
        }
    }
