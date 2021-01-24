    public class Headers
    {
        public string TransactionFrom { get; set; }
        public string TransactionTo { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
    
    public class Transaction
    {
        public string logisticCode { get; set; }
        public string siteId { get; set; }
        public string userId { get; set; }
        public string dateOfTransaction { get; set; }
        public string price { get; set; }
        public string packSale { get; set; }
    }
