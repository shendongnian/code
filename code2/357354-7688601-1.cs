    public class Factory<T> where T : new()
    {
      public T Create()
      {
        return new T();
      }
    }
