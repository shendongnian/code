    [DataContract]
    public class MyClass
    {
        public string WillNotSerializeString { get; set; }
    
        [DataMember]
        public string WillSerializeString { get; set; }
    
        [DataMember]
        public int WillSerializeInt { get; set; }
    
        [DataMember]
        public byte[] WillSerializeByteArray { get; set; }
    }
