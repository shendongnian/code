    public interface IRepository<T>
    {
        T Save(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        Question GetById(int id);
    }
