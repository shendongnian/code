    [ModelBinder(BinderType = typeof(ReceivedMessageEntityBinder))]
        public class ReceivedMessage
        {
            public long Id { get; set; }
    
            [StringLength(12)]
            public string Msisdn { get; set; }
            public string RequestId { get; set; }
            public DateTime Timestamp { get; set; }
            public string Keyword { get; set; }
            public string UserData { get; set; }
            public string Da { get; set; }
        }
