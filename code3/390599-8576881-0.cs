    public interface IService<T>
    {
      void AddOrUpdate(T entity);
      T Get(T entity);
      // etc
    }
