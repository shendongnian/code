    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    
        // Expressions!!!! Func will load all items to memeory
        // and then perform filtering by linq-to-objects!!!!!!
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);
    
        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
    }
