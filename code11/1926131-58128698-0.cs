    public class NameInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string StreetName { get; set; }
        public int ApartmentNumber { get; set; }
    }
