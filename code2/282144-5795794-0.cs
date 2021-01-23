    public TEntity GetById<TEntity>(params Expression<Func<TEntity, bool>>[] keys) where TEntity : class
    {
        if (keys == null)
          return default(TEntity);
        var table = context.CreateObjectSet<TEntity>();
        IQueryable<TEntity> query = null;
        foreach (var item in keys)
        {
            if (query == null)
                query = table.Where(item);
            else
                query = query.Where(item);
        }
        return query.FirstOrDefault();
    }
