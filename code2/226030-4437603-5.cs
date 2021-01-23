    public class DataRepository<T> : IRepository<T> where T : class
    {
       private ObjectContext _ctx; 
 
       public DataRepository<T>(ObjectContext ctx)
       {
          this._ctx = ctx;
       }
       public IObjectSet<T> CurrentEntitySet<T>()
       {
           get
           {
              var entityName = _plularizer.Pluralize(typeof(T).Name);
              string entitySetName = string.Format("{0}.{1}", EntityContainerName, entityName);
              return _ctx.CreateObjectSet<T>(entitySetName );  
           }
       }
    }
