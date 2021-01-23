    public class SomeClass
    {
        private readonly Lazy<Foo> foo = new Lazy<Foo>(SomeHeayCalculation);
        // ... constructor and other stuff
    
        public Foo SomeProperty
        {
            get
            {
                return foo.Value;
            }
        } 
    }
