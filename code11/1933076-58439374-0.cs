    public class Address 
    {
        public string HouseNumber { get; set; }
        public string FlatPosition { get; set; }
        public string AddressLine { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
    public YourEntity
    {
        public int Id { get; set; } // or whatever you use
        // other properties
        // complex type properites
        public Address LandlordAddress { get; set; }
        public Address LandlordAgentAddress { get; set; }
    }
