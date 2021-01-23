    public class RepositoryScanner : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (type.BaseType == null) return;
            if (type.GetInterface(typeof(IRepository).Name) != null)
            {
                var name = type.Name;
                registry
                   .For<IRepository>()
                   .AddInstances(y => y.Instance(new ConfiguredInstance(type).Named(name)));
            }
        }
    }
