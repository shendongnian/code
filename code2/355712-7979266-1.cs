    [DataContract(Name = "Details", Namespace = "")]
    public class Details
    {
        [DataMember]
        public Int32 AccNo;
        [DataMember]
        public Int32 CostCentreNo;
        [DataMember]
        public Int32 TransactionType;
        [DataMember]
        public Boolean Outstanding;
        [DataMember]
        public DateTime? CheckStartDate;
        [DataMember]
        public DateTime? CheckEndDate;
        public Details()
        {}
    }
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/Transactions",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
    List<Transactions> GetTransactions(Details details);
