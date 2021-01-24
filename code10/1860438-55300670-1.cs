    [XmlRoot(ElementName = "ApproversList")]
    public class ApproversList
    {
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public Item[] Item { get; set; }
    }
