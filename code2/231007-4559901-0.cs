    public static void AssignTo<T>(this IEnumerable<T> source, out T dest1, out T dest2)
    {
        using (var e = source.GetEnumerator())
        {
            dest1 = e.MoveNext() ? e.Current : default(T);
            dest2 = e.MoveNext() ? e.Current : default(T);
        }
    }
