    [DataContract(Namespace = "http://www.yournamespace/")]
    public class MyObject
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public String Name { get; set; }
    }
