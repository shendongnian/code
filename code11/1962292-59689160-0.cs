    public class Headers
    {
        public string TransactionFrom { get; set; }
        public string TransactionTo { get; set; }
        public List<Transaction1> Transactions { get; set; }
    }
    
    public class Transaction
    {
        [ChoFieldPosition(4)]
        public string logisticCode { get; set; }
        [ChoFieldPosition(5)]
        public string siteId { get; set; }
        [ChoFieldPosition(6)]
        public string userId { get; set; }
        [ChoFieldPosition(2)]
        public string dateOfTransaction { get; set; }
        [ChoFieldPosition(1)]
        public string price { get; set; }
    }
