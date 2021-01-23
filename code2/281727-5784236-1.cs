    public static IQueryable<T> OptionalWhere<T>(this IQueryable<T> query, int? id, Expression<Func<T, int, bool>> filter)
    {
        if (id.HasValue)
        {
            var idValue = id.Value;
            query = query.Where(e => filter(e, idValue));
        }
        return query;
    }
