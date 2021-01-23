    public class FactoryUser
    {
        [Import]
        public IEnumerable<Lazy<FooFactory,IDictionary<string,object>>> Factories 
        {
            get;
            set;
        }
    
        public void DoSomething()
        {
           var factory = Factories.First(x => x.Metadata["foo"] == "bar");
        }
    }
