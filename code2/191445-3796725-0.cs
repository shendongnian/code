    public static T OneOrDefault<T>(this IEnumerable<T> list)
    {
        using (var e = list.GetEnumerator())
        {
            if (!e.MoveNext())
                return default(T);
            T val = e.Current;
            if (e.MoveNext())
                return default(T);
            return val;
        }
    }
