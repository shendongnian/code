    public static IEnumerable<T> StripConsecutives<T>(this IEnumerable<T> source, T value, IEqualityComparer<T> comparer)
    {
        // null-checking omitted for brevity
        
        using (var enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
            else
            {
                yield break;
            }
            
            T prev = enumerator.Current;
            while (enumerator.MoveNext())
            {
                T current = enumerator.Current;
                if (comparer.Equals(prev, value) && comparer.Equals(current, value))
                {
                    // This is a consecutive occurrence of value --
                    // moving on...
                }
                else
                {
                    yield return current;
                }
                prev = current;
            }
        }
    }
