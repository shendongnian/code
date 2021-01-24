        public class Account
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public decimal StartingBalance { get; set; }
        }
        public class Tag
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
        public class Transaction
        {
            public long Id { get; set; }
            public decimal Amount { get; set; }
            public string Memo { get; set; }
            public long? TagId { get; set; }
            public Tag Tag { get; set; }
            public long? AccountId { get; set; }
            public Account Account { get; set; }
        }
