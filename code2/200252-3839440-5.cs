    public IEnumerable<T> FindConsecutiveDuplicates<T>(this IEnumerable<T> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            T current = iterator.Current;
            while (iterator.MoveNext())
            {
                if (EqualityComparer<T>.Default.Equals(current, iterator.Current))
                {
                    yield return current;
                }
                current = iterator.Current;
            }
        }
    }
