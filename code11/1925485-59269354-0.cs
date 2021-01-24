    public class Transaction {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public BillAmount BillAmount { get; set; }
    }
    public class Customer {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class BillAmount {
        public string Id { get; set; }
        public double Amount { get; set; }
    }
