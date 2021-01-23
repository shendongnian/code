    class Class1
    {
        //Properties
        public string Property1 { get; set; }
        public List<object> Property2 { get; set; }
        public Class1(string property1, List<object> property2)
        {
            Contract.Requires(property1 != null);
            Contract.Requires(property2 != null);
            Property1 = property1;
            Property2 = property2;
        }
        public Class1(string property1)
            : this(property1, new List<object>())
        { }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Property1 != null);
            Contract.Invariant(Property2 != null);
        }
    }
