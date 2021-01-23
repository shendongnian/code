    public interface IEntity
    {
        int Id { get; }
    }
    public interface IRepository<T> where T : class, IEntity 
    {
        IQueryable<T> GetQuery();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
