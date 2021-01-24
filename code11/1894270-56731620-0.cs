    public class CallbackResultsJson
    {
        public CallbackResultsClass CallbackResults { get; set; }
        public string RequestNumber { get; set; }
        public class CallbackResultsClass
        {
            public int Status { get; set; }
            public string Message { get; set; }
            public string[] Data { get; set; }
            public string Log { get; set; }
            public string TransactionToken { get; set; }
        }
    }
