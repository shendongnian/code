    public static bool AllEqual<T>(this IEnumerable<T> source, out T value)
    {
        using (var enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                value = default(T);
                return true;
            }
            value = enumerator.Current;
            var comparer = EqualityComparer<T>.Default;
            while (enumerator.MoveNext())
            {
                if (!comparer.Equals(value, enumerator.Current))
                {
                    return false;
                }
            }
            return true;
        }
    }
