    public abstract class GenericRepository<T> : IRepository<T>
    {
       private IObjectSet<T> _ObjectSet; // get this in via DI (for example)
    
       public T FindSingle(Expression<T,bool>> predicate)
       {
          return _ObjectSet.SingleOrDefault(predicate);
       }
    
       // you can figure out how to do the other implementation methods
    }
