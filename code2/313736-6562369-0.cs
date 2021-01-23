    [DataContract]
    public class ServiceResponse
    {
        [DataMember(Name = "servicename")]
        public string ServiceName { get; set; }
    }
    [DataContract]
    class Response
    {
        [DataMember(Name = "serviceresponse")]
        public ServiceResponse ServiceResponse { get; set; }
    }
