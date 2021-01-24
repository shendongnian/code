    [XmlRoot(ElementName = "Purchase")]
    public class Purchase
    {
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "Volume")]
        public string Volume { get; set; }
    }
    [XmlRoot(ElementName = "Sell")]
    public class Sell
    {
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "Volume")]
        public string Volume { get; set; }
    }
    [XmlRoot(ElementName = "TimeStep")]
    public class TimeStep
    {
        [XmlElement(ElementName = "TimeStepID")]
        public string TimeStepID { get; set; }
        [XmlElement(ElementName = "Purchase")]
        public List<Purchase> Purchase { get; set; }
        [XmlElement(ElementName = "Sell")]
        public List<Sell> Sell { get; set; }
    }
    [XmlRoot(ElementName = "DeliveryDay")]
    public class DeliveryDay
    {
        [XmlElement(ElementName = "Day")]
        public string Day { get; set; }
        [XmlElement(ElementName = "TimeStep")]
        public List<TimeStep> TimeStep { get; set; }
    }
    [XmlRoot(ElementName = "MarketArea")]
    public class MarketArea
    {
        [XmlElement(ElementName = "MarketAreaName")]
        public string MarketAreaName { get; set; }
        [XmlElement(ElementName = "DeliveryDay")]
        public DeliveryDay DeliveryDays { get; set; }
    }
    [XmlRoot(ElementName = "BidAskCurves")]
    public class BidAskCurves
    {
        [XmlElement(ElementName = "MarketArea")]
        public MarketArea MarketAreas { get; set; }
    }
