     public class CallbackResults
        {
            public string TransactionToken { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
            public List<string> Data { get; set; }
            public List<string> Log { get; set; }
        }
    
        public class CallbackResultsRootObj
        {
            public CallbackResults VdiCallbackResults { get; set; }
            public string RequestNumber { get; set; }
        }
      var vdiTransactionResult = JsonConvert.DeserializeObject<CallbackResultsRootObj>(requestBody);
