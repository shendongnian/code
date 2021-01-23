    public class SomeClass
    {
        // ... constructor and other stuff
        private Foo _foo;
    
        public Foo SomeProperty
        {
            get
            {
                return _foo ?? (_foo = SomeHeayCalculation());
            }
        } 
    }
