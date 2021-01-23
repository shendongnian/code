    public class BillingItem
    {
        [XmlElement("name")]
        public string Description { get; set; }
    }
    [XmlRoot("root")]
    public class MyResult
    {
        [XmlElement("item")]
        public List<BillingItem> Items { get; set; }
    }
