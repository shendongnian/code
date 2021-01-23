    public class FactoryUser
    {
        [ImportMany]
        public Lazy<IServiceProviderFactory,IDictionary<string,object>>[] Factories 
        {
            get;
            set;
        }
    
        public void DoSomething()
        {
           var factory = Factories.First(x => x.Metadata["foo"] == "bar").Value;
           var serviceProvider = factory.CreateServiceProvider(someDependency);
           ...
        }
    }
