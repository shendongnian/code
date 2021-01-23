    public interface IRepository<T>
    {
        int Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> FindAll(DetachedCriteria criteria);
        ...
        .
        .
        //
    }
