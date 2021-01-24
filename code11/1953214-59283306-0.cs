    [XmlRoot]
    public class Root
    {
        [XmlElement]
        public Address BillingAddress { get; set; }
        [XmlElement]
        public Address DeliveryAddress { get; set; }
    }
    public class Address
    {
        [XmlElement]
        public string AddressType { get; set; }
        [XmlElement]
        public string StreetName{ get; set; }
        [XmlElement]
        public string HouseNumber { get; set; }
        [XmlElement]
        public string PostCode { get; set; }
        [XmlElement]
        public string PostalPlace { get; set; }
        [XmlElement]
        public string CountryCode { get; set; }
    }
