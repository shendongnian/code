    [DataContract]
    [KnownType(typeof(SomeData))]
    public class ConsoleData
    {
        [DataMember]
        public String Description { get; set; }
    
    }
    
    [DataContract]
    public class SomeData : ConsoleData
    {
    
        [DataMember]
        public int Volume { get; set; }
        ......
