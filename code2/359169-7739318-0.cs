    interface IUniqueEntity
    {
      int ID { get; }
    }
    
    abstract class FooBarBase<TEntity>
      where TEntity : class, IUniqueEntity
    {
      private DataContext _ctx;
    
      public Foo(DataContext context)    {
          _ctx = context;
      }
    
      protected abstract DoSomeThing();
    
      protected TEntity DataAccess(int ID)
      {
          return _ctx.GetTable<TEntity>()
            .First(e => object.Equals(e.ID, ID);
      }
    }
