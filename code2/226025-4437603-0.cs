    public class DataRepository<T> : IRepository<T> where T : class
    {
       private IObjectSet<T> _CurrentEntitySet<T>();
    
       public IObjectSet<T> CurrentEntitySet<T>()
       {
           get
           {
              var entityName = _plularizer.Pluralize(typeof(T).Name);
              string entitySetName = string.Format("{0}.{1}", EntityContainerName, entityName);
              return CreateObjectSet<T>(entitySetName );  
           }
       }
    }
