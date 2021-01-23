     interface ITest
    {
        IEnumerable<int> Integers { get; set; }
    }
    class Test : ITest
    {
        public IEnumerable<int> Integers { get; set; }
        public Test()
        {
            Integers = new List<int>();
        }
    }
