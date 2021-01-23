    // this is my business model object
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        // notice the Address object nested in the Person class
        public Address HomeAddress { get; set; }
    }
    // this is another class that lives inside the person class
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
