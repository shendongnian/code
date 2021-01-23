    class GenericClass<T> : Class where T : new()
    {
      public T Results {get; protected set;}
      public GenericClass (T results, Int32 id) : base (id)
      {
        Results=results;
      }
      public static GenericClass<T> Something (Int32 id)
      {
       return new GenericClass<T> (new T(), id); 
      }
    }
