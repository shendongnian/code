    public static IEnumerable<T> Zip<T>(IEnumerable<T> first, IEnumerable<T> second, Func<T,T,T> aggregator)
    {
        using (var firstEnumerator = first.GetEnumerator())
        using (var secondEnumerator = second.GetEnumerator())
        {
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return aggregator(firstEnumerator.Current, secondEnumerator.Current);
            }
            while (firstEnumerator.MoveNext())
            {
                yield return firstEnumerator.Current;
            }
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }
        }
    }
