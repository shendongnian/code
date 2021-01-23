    public class ComponentAttribute : Attribute
    {}
    
    // class that should be registered in the container.
    [Component]
    public class MyService : IMyService
    {}
    
    // Contains information for each class that should be 
    // registered in the container.
    public interface IContainerMapping
    {
        public Type ImplementationType {get;}
        public IEnumerable<T> ImplementedServices {get; }
    }
    
    public class ComponentProvider
    {
        public static IEnumerable<IContainerMapping> Find() 
        {
            var componentType = typeof(ComponentAttribute);
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
               if (type.GetCustomAttributes(componentType, false).Count == 0)
                  continue;
    
               var mapping = new ContainerMapping(type);
               List<Type> interfaces new List<Type>();
               foreach (var interfac in type.GetInterfaces())
               {
                 //only get our own interfaces.
                 if (interface.Assembly != Assembly.GetExecutingAssembly())
                   continue;
    
                 interfaces.Add(interfac);
               }
    
               mapping.ImplementedServices = interfaces;
               yield return mapping;
            }
        }
    }
