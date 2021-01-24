    public class Id
    {
    }
    public class Address
    {
        public string Street { get; set; }
    }
    public class Person
    {
        public string PersonNumber { get; set; }
        public Address Address { get; set; }
        public string email { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
    }
    public class NestedObject
    {
        public Id Id { get; set; }
        public string ItemNumber { get; set; }
        public Person Person { get; set; }
        public Contact Contact { get; set; }
        public string Quantity { get; set; }
    }
    
