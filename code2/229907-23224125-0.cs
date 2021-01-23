    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
