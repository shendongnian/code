    public static IQueryable<T> DynamicWhere<T>(this IQueryable<T> src, string propertyName, string value)
    {
        var pe = Expression.Parameter(typeof(T), "t");
        var left = Expression.Property(pe, typeof(T).GetProperty(propertyName));
        var right = Expression.Constant(value);
        // Illustrated a equality condition but you can put a switch based on some parameter
        // to have different operators
        var condition = Expression.Equal(left, right);
        var predicate = Expression.Lambda<Func<T, bool>>(condition, pe);
        return src.Where(predicate);
    }
