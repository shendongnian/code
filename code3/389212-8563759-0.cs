    public class BaseMasrhalByRefObject : MasrhalByRefObject, IDescriptor
    {
       public BaseMasrhalByRefObject() : base() {}
       
       public List<string> GetInterfaces()
       {
          List<string> types = new List<string>();
          foreach(Type i in GetType().GetInterfaces())
          {
             types.Add(i.AssemblyQualifiedName);
          }
          return types;
       }
    }
