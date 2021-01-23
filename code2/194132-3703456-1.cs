    public static IQueryable<T> Where<T>(
        this IQueryable<T> source, string columnName, string keyword)
    {
        var arg = Expression.Parameter(typeof(T), "p");
        var body = Expression.Call(
            typeof(Queryable),
            "Contains",
            new Type[] { typeof(string) },
            Expression.Property(arg, columnName),
            Expression.Constant(keyword));
        var predicate = Expression.Lambda<Func<T, bool>>(body, arg);
        return source.Where(predicate);
    }
