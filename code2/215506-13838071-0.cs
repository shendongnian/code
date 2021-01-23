    [DataContract]
    public class MyClass
    {
        [DataMember]
        public string ID { get; set; }
        [IgnoreDataMember]
        public string MySecret { get; set; }
    }
