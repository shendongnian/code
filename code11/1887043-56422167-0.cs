    [XmlRoot(ElementName = "FindOrderResponse", Namespace = "http://www.courier.com/schemas/")]
    public class FindOrderResponse
    {
        [XmlArray("Orders")]
        [XmlArrayItem("Order")]
        public List<Order> Orders { get; set; }
        [XmlAttribute(AttributeName = "m", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string M { get; set; }
    }
