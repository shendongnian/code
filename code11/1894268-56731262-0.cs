public class CallbackResultsJson
{
    public CallBackResults CallbackResults { get; set; }
    public string RequestNumber { get; set; )
    
    public class CallbackResults
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public string Log { get; set; }
        public string StatusText { get; set; }
        public string TransactionToken { get; set; }
    }
}
var TransactionResult = JsonConvert.DeserializeObject<CallbackResultsJson>(requestBody);
