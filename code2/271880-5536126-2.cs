    public class Person
    {
        public decimal Salary { get;set; }
        public string Name { get; set; }
        public readonly object SyncRoot = new object();
    }
