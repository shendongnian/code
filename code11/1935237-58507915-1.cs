    public class Customer
    {
        public string Name { get; set; }
        [XmlElement("Order")]
        public List<Order> Orders{ get; set; }
    }
