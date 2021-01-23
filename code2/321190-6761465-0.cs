    [DataContract(Namespace = "http://abc.com/"]
    public class Apple
    {
        [DataMember]
        public bool IsEvil { get; set; }
        [IgnoreDataMember]
        public bool IsPoisoned { get; set; }
    }
