    [XmlRoot("Purchase")]
    public class Purchase
    {
        [XmlElement("Price")]
        public string Price { get; set; }
        [XmlElement("Volume")]
        public string Volume { get; set; }
    }
    
    [XmlRoot("Sell")]
    public class Sell
    {
        [XmlElement("Price")]
        public string Price { get; set; }
        [XmlElement("Volume")]
        public string Volume { get; set; }
    }
    
    [XmlRoot("TimeStep")]
    public class TimeStep
    {
        [XmlElement("TimeStepID")]
        public string TimeStepID { get; set; }
        [XmlElement("Purchase")]
        public List<Purchase> Purchase { get; set; }
        [XmlElement("Sell")]
        public List<Sell> Sell { get; set; }
    }
    
    [XmlRoot("DeliveryDay")]
    public class DeliveryDay
    {
        [XmlElement("Day")]
        public string Day { get; set; }
        [XmlElement("TimeStep")]
        public List<TimeStep> TimeStep { get; set; }
    }
    
    [XmlRoot("MarketArea")]
    public class MarketArea
    {
        [XmlElement("MarketAreaName")]
        public string MarketAreaName { get; set; }
        [XmlElement("DeliveryDay")]
        public DeliveryDay DeliveryDay { get; set; }
    }
    
    [XmlRoot("BidAskCurves")]
    public class BidAskCurves
    {
        [XmlElement("MarketArea")]
        public MarketArea MarketArea { get; set; }
    }
