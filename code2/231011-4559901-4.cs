    public static void AssignToExact<T>(this IEnumerable<T> source, out T dest1, out T dest2)
    {
        using (var e = source.GetEnumerator())
        {
            if (e.MoveNext()) dest1 = e.Current;
            else throw new ArgumentException("Only 0 of 2 arguments given", "source");
            if (e.MoveNext()) dest2 = e.Current;
            else throw new ArgumentException("Only 1 of 2 arguments given", "source");
            if (e.MoveNext()) throw new ArgumentException("More than 2 arguments given", "source");
        }
    }
