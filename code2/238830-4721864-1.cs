    public class FooLookup : Lookup<int, List<Foo>, Foo>
    {
        public FooLookup(IDictionary<int, List<Foo>> dict)
            : base(dict)
        {            
        }
    }
