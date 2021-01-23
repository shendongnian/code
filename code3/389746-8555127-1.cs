    [DataContract]
    public class ConsoleData
    {
        [DataMember]
        public String Description { get; set; }
    }
    [DataContract, KnownType(typeof(ConsoleData))]
    public class SomeData : ConsoleData
    {
        [DataMember]
        public int Volume { get; set; }
    }
