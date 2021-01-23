    public interface IRepository<T> where T : class
    {
       T FindSingle(Expression<Func<T,bool>> predicate);
       IQueryable<T> FindAll(); // optional - matter of preference
       void Add(T entity);
       void Remove(T entity);
    }
