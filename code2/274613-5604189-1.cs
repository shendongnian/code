    public static int Count(this IEnumerable source)
    {
        var list = source as IList;
        if (list != null)
            return list.Count;
        int c = 0;
        using (var e = source.GetEnumerator())
        {
            while(e.MoveNext())
                c++;
        }
        return c;
    }
