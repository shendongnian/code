    public class Person
    {
        public Person(string firstName, string lastName, int age,
            string streetAddress, string city, string state, int zipCode)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
