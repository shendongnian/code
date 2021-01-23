    namespace xxxx.Common.Repositories.InMemory // note how this is an 'in-memory' repo
    {
       public class GenericRepository<T> : IDisposable, IRepository<T> where T : class
       {
          public delegate void UpdateComplexAssociationsHandler<T>(T entity);
          public event UpdateComplexAssociationsHandler<T> UpdateComplexAssociations;
    
          // ... snip heaps of code
    
          public void Add(T entity) // method defined in IRepository<T> interface
          {
             InMemoryPersistence<T>().Add(entity); // basically a List<T>
             OnAdd(entity); // fire event
          }
    
          public void OnAdd(T entity)
          {
             if (UpdateComplexAssociations != null) // if there are any subscribers...
                UpdateComplexAssociations(entity); // call the event, passing through T
          }
       }
    }
