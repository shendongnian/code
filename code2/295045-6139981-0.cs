    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/UnknownProject")]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
    }
    
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/UnknownProject"]
    public class Student : Person
    {
        [DataMember]
        public int StudentId { get; set; }
    }
