    public class BankB : IBankData
    {
        public string BankName => "BankB";
        public IBankTransaction Transaction { get; set; }
    }
    public class BankBTransaction : IBankTransaction
    {
        // Bank B specific properties
        public string Name { get; set; }
        // ... additional Bank B specific properties
        // ...
        // interface implemented properties
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }        
    }
