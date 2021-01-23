    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
    }
    
    [CollectionDataContract(Name = "People")]
    public class People : List<Person>
    {
    }
