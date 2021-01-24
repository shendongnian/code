    public interface IBankData
    {
        string BankName { get; }
        // ... additional bank meta data properties
        // ...
        IBankTransaction Transaction { get; set; }
    }
    public interface IBankTransaction
    {
        [JsonProperty("ACC_ID")]
        string AccountId { get; set; }
        [JsonProperty("ACCOUNT_NO")]
        string AccountNumber { get; set; }
        // ... additional shared bank transaction properties
        // ...
    }
