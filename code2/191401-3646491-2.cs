    public static IEnumerable<TSource> ZipMerge<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
    {
        using (var secondEnumerator = second.GetEnumerator())
        {
            foreach (var item in first)
            {
                yield return item;
                if (secondEnumerator.MoveNext())
                    yield return secondEnumerator.Current;
            }
            while (secondEnumerator.MoveNext())
                yield return secondEnumerator.Current;
        }
    }
