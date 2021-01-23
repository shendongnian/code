    class Repository : IRepository
    {
       public IDataContext Context { get; set; }
       public T Get<T>(int id) where T : IEntity, new()
      {
          return Context.Get<T>(id);
      }
    }
