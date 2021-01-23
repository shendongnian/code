    public class NestedInheritanceConvention : IRegistrationConvention
    {
        public void Process (Type type, Registry registry)
        {
            if (type.IsInterface)   
                return;
            if (type.IsAbstract)    
                return;
            if (type.IsSubclassOf (typeof(Registry)))
                return;
            foreach (var iface in type.GetInterfaces ())
            {
                registry.For (iface).Use (type);
            }
        }
    }
