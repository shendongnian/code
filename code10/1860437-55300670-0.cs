    [XmlRoot(ElementName = "ApproversList")]
    public class ApproversList
    {
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public IEnumerable<Item> Item { get; set; } // or Item[]
    }
