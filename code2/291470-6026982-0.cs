    public interface IDAO<T>
    {
        T Find(object key);
        List<T> Get(T c);
        void Persist(T obj);
    }
  
