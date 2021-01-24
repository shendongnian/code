    public static IOrderedQueryable<TEntity> ThenById<TEntity>(
        this IOrderedQueryable<TEntity> source)
            where TEntity : IHasId
    {
        return source.ThenBy(e => e.Id);
    }
