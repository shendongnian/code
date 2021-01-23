    public static int Count(this IEnumerable source)
    {
        int c = 0;
        using(var e = source.GetEnumerator())
        {
            while(e.MoveNext())
                c++;
        }
        return c;
    }
