    public class BankA : IBankData
    {
        public string BankName => "BankA";
        public IBankTransaction Transaction { get; set; }
    }
    public class BankATransaction : IBankTransaction
    {
        // Bank A specific properties
        [JsonProperty("GROUPName")]
        public string GroupName { get; set; }
        // ... additional Bank A specific properties
        // ...
        // interface implemented properties
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
    }
