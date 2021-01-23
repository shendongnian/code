    public static TEntity GetByID<TEntity>(this IEnumerable<TEntity> list, long id) where TEntity : Identifiable
    {
        var query = list as IQueryable<TEntity>;
        if (query != null)
            return query.SingleOrDefault(e => e.ID == id);
        return list.SingleOrDefault(e => e.ID == id);
    }
