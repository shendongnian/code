    [DebuggerDisplay("{Name} - {StockSymbol}")]
    public class Company
    {
        public string Name { get; set; }
        public string StockSymbol { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public Company(string name) { Name = name; }
    }
