    [DataContract] // Removed Namespace or keep both namespace the same
    public class Parent
    {
        [DataMember]
        public Child Child;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
    }
    [DataContract]
    public class Child
    {
        [DataMember]
        public int Age;
    }  
