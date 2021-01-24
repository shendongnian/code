    public class BankC : IBankData
    {
        public string BankName => "BankC";
        public IBankTransaction Transaction { get; set; }
    }
    public class BankCTransaction : IBankTransaction
    {
        // Bank B specific properties
        public string FullName { get; set; }
        // ... additional Bank B specific properties
        // ...
        // interface implemented properties
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
    }
