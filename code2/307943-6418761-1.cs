    public static Pagination<TEntity> GetPagination<TEntity>(this Repository<TEntity> repository, 
       Expression<Func<TEntity, bool>> filter, int pageSize, int pageIndex)
    {
       var entities = repository.GetCollection(filter, pageSize, pageIndex);
       var count = repository.Count(filter);
    
       return new Pagination(entities, pageSize, pageIndex + 1, count);
    }
