    public interface IRep<TEntity>
    {
        IEnumerable<TEntity> Get<TOrderBy>(
            Expression<Func<TEntity, TOrderBy>> orderBy
        );
    }
