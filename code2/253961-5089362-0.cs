    public class ReturnsWrapper {
        [XmlElement("OrderedShareClassReturn")]
        public List<OrderedShareClassReturn> Items { get; set; }
        [XmlAttribute("order")]
        public string Order {get;set;}
    }
