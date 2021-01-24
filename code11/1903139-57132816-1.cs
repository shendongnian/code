    [DataContract(Namespace = "http://companyname.com/schemas/student")]
    public class Student
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
