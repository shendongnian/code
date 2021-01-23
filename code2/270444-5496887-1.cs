    public static IQueryable<TEntity> GetUserEntities(this IQueryable<TEntity> query, string user) 
        where TEntity : IEntity 
    {
       return query.Where(e => e.CreatedBy == user);
    }
