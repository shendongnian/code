    class Test : ITest
    {
        // satisfies interface explicitly when called from ITest reference
        IEnumerable<int> ITest.Integers
        {
            get
            {
                return this.Integers; 
            }
            set
            {
                this.Integers = new List<int>(value);
            }
        }
        // allows you to go directly to List<int> when used from reference of type Test
        public List<int> Integers { get; set; }
    }
