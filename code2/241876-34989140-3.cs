    [DataContract]
    class Company
    {
        [DataMember]
        public string Name { get; set }
        
        [DataMember]
        public Person[] People { get; set }
    }
    
    [DataContract]
    class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
    }
