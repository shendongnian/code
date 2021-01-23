    [DataContract]
    [KnownType(typeof(ErrorResponse)]
    public class BasicResponse
    {
        [DataMember]
        public string status { get; set; }
    }
    
    [DataContract]
    public class ErrorResponse : BasicResponse
    {
        [DataMember]
        public string errorMsg { get; set; }
    }
