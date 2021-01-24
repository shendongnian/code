    public class RootObject
    {
        public List<Customer> customer { get; set; }
    }
    public class Customer
    {
        public Dictionary<string, List<string>> emailAddress{ get; set; }
        public Dictionary<string, List<string>> custPhone{ get; set; }
        public string custIDString { get; set; }
    }
