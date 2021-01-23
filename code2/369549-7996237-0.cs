    interface ITest
    {
        IEnumerable<int> Integers { get; set; }
    }
    class Test : ITest
    {
        // if this were allowed....
        public List<int> Integers { get; set; }
    }
