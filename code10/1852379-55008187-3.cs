    public class Address
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Type { get; set; }
        public bool IsMainAddress { get; set; }
        public string Route { get; set; }
        public string State { get; set; }
        public Guid CustomerId { get; set; }
        // If you want to use class reference navigation property (also called as "hard reference").
        // That can be used in "$expand" or "$select" for example.
        // Uncomment the following line:
        // public Customer Customer { get; set }
    }
