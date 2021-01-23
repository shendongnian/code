    public class Person
    {
        public Person(string firstName, string lastName, int age, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Address = address;
        }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public Address(string streetAddress, string city, string state, int zipCode)
        {
             this.StreetAddress = streetAddress;
             this.City = city;
             this.State = state;
             this.ZipCode = zipCode;
        }
    
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
