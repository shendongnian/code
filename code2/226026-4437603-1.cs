    public class DataRepository<T> : IRepository<T> where T : class
    {
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
