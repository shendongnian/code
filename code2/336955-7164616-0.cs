    public static IEnumerable<T> IntersectSorted<T>(this IEnumerable<T> sequence1,
        IEnumerable<T> sequence2,
        IComparer<T> comparer)
    {
        using (var cursor1 = sequence1.GetEnumerator())
        using (var cursor2 = sequence2.GetEnumerator())
        {
            if (!cursor1.MoveNext() || !cursor2.MoveNext())
            {
                yield break;
            }
            var value1 = cursor1.Current;
            var value2 = cursor1.Current;
            while (true)
            {
                int comparison = comparer.Compare(value1, value2);
                if (comparison < 0)
                {
                    if (!cursor1.MoveNext())
                    {
                        yield break;
                    }
                    value1 = cursor1.Current;
                }
                else if (comparison > 0)
                {
                    if (!cursor2.MoveNext())
                    {
                        yield break;
                    }
                    value2 = cursor2.Current;
                }
                else
                {
                    yield return value1;
                    if (!cursor1.MoveNext() || !cursor2.MoveNext())
                    {
                        yield break;
                    }
                    value1 = cursor1.Current;
                    value2 = cursor2.Current;
                }
            }
        }
    }
