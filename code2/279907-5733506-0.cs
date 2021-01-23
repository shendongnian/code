    public static IQueryable<T> Where<T>(this IQueryable<T> source,
        string predicate, params object[] values)
    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source,
        string ordering, params object[] values)
    //...and more like GroupBy, Select
