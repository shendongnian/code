    public static IQueryable<T> Where<T>(
        this IQueryable<T> source, string columnName, string keyword)
    {
        var arg = Expression.Parameter(typeof(T), "p");
        var body = Expression.Call(
            Expression.Property(arg, columnName),
            "Contains",
            null,
            Expression.Constant(keyword));
        var predicate = Expression.Lambda<Func<T, bool>>(body, arg);
        return source.Where(predicate);
    }
