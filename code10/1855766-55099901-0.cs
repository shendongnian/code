    [DataContract]
    private class Person
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "surname")]
        public string Surname { get; set; }
    }
    [DataContract]
    private class Entities
    {
        [DataMember(Name = "entities")]
        public Person[] Persons { get; set; }
    }
    
