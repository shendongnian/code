    public PageOf<TEntity> GetPageOfEntity<TEntity>(int pageNumber, int pageSize)
        where TEntity : Entity
    {
        Type entityType = typeof(TEntity);
        ...
    }
