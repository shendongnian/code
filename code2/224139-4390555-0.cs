    GenericClass<T> : Class where T : new()
    {
      T Results {get; protected set;}
      public GenericClass<T> (T results, Int32 id)
      {
        Results=results;
      }
      public GenericClass<T> Something (Int32 id) : this(new T(), id)
      { }
    }
