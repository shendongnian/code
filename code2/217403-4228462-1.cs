    [XmlRoot("products")]
    public class Products
    {
        [XmlElement("label")]
        public string Label { get; set; }
        [XmlElement("cars")]
        public Cars Cars { get; set; }
    }
