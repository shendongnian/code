    [DataContract]
    public class Account
    {
        [DataMember]
        public string AccountNo { get; set; } 
        public string AccountName { get; set; }  **// client won't see this data.**
    }
