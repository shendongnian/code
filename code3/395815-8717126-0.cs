    public class SomeClass<T>
    {
        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(typeof(System.Enum).IsAssignableFrom(typeof(T)));
        }
        /// <summary>Initializes a new instance of the SomeClass class.</summary>
        /// <param name="dependency"></param>
        public SomeClass()
        {
            
        }
    }
    public class SomeOtherClass
    {
        public SomeOtherClass()
        {
            var myClass = new SomeClass<int>();
        }
    }
