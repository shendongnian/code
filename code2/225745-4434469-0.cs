    public class GenericRepository<T> : IRepository<T> where T : class
    {
       public void Update<T2>(T2 entity) where T2: class, new()
       {
          var stub = new T2(); // create stub, now you see why we need new() constraint
    
          object entityKey = null;
          // ..snip code to get entity key via attribute on all domain entities
          // once we have key, set on stub.
    
          // check if entity is already attached..
          ObjectStateEntry entry;
          bool attach;
    
          if (CurrentContext.ObjectStateManager.TryGetObjectStateEntry(CurrentContext.CreateEntityKey(CurrentContext.GetEntityName<T>(), stub), out entry))
          {
             // Re-attach if necessary.
    	     attach = entry.State == EntityState.Detached;
          }
          else
          {
    	     // Attach for first time.
    	     attach = true;
          }
    
          if (attach)
             CurrentEntitySet.Attach(stub as T);
    
          // Update Model. (override stub values attached to graph)
          CurrentContext.ApplyCurrentValues(CurrentContext.GetEntityName<T>(), entity);
       }
    }
