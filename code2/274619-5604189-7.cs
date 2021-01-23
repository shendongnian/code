    public static int Count(this IEnumerable source) 
    {
        var col = source as ICollection; 
        if (col != null)
            return col.Count; 
        int c = 0;
        var e = source.GetEnumerator();
        DynamicUsing(e, () =>
        {
            while (e.MoveNext())
                c++;
        });
        return c;
    }
