    public class MyClass
    {
        public int status { get; set; }
        public string msg { get; set; }
        public Dictionary<string, Transaction> transaction_details { get; set; }
    }
    public class Transaction
    {
        public string mihpayid { get; set; }
        public string request_id { get; set; }
        public string bank_ref_num { get; set; }
    }
