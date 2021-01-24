    [DelimitedRecord(",")]
    [XmlRoot(ElementName = "MarketingAllCardholderData")]
    public class MarketingAllCardholderData
    {
        [XmlElement(ElementName = "CentreName")]
        public string CentreName { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "CustomerId")]
        public string CustomerId { get; set; }
        [XmlElement(ElementName = "DOB")]
        public string DOB { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "ExpiryDate")]
        public string ExpiryDate { get; set; }
    }
    [DelimitedRecord(",")]
    [XmlRoot(ElementName = "MarketingAllCardholder")]
    public class MarketingAllCardholder
    {
        [XmlElement(ElementName = "MarketingAllCardholderData")]
        public List<MarketingAllCardholderData> MarketingAllCardholderData { get; set; }
    }
