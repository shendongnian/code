    [DataContract]
    public class Person
    {
        [DataMember(Name = "PER_NAME", Order = 1)]
        public string Name { get; set; }
        [DataMember(Name = "PER_AGE", Order = 2)]
        public int Age { get; set; }
        [DataMember(Name = "PER_ADDRESS", Order = 3)]
        public Address PostalAddress { get; set; }
    }
