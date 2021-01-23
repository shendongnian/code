    public interface IUnitOfWork
    {
        IRepository<T> GenerateRepository<T>();
        void SaveChanges();
    }
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> Find();
        public T Create(T newItem);
        public T Delete(T item);
        public T Update(T item);
    }
