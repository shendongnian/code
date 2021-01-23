    public static IQueryable<T> WhereValueOrNull<T, int?>(this IQueryable<T> query, int? id, Expression<Func<T, int, bool>> filter)
    {
        if (id.HasValue)
        {
            query = query.Where(e => filter(e, id.Value));
        }
        return query;
    }
