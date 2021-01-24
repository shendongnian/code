    public interface ISelector<TEntity>
        where TEntity : class
    {
        bool Matches(TEntity entity);
    }
