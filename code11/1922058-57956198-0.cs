    [DataContract] // Need this to serialize classes without default constructor.
    public class Person
    {
        public Person(string name, DateTime dob)
        {
            this.Name = name;
            this.DateOfBirth = dob;
        }
    
        [DataMember] // Need this to serialize this property
        public string Name { get; private set; } // Need setter for serializer to work
    
        [DataMember]
        public DateTime DateOfBirth { get; private set; }
    }
