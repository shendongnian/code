    [XmlRoot(ElementName = "SalesOrders", Namespace = "")]
    public class MyArbitraryName
    {
        [XmlElement("SalesOrder")]
        public List<SalesOrder> Orders { get; set; }
    }
    public class SalesOrder 
    {
        public int Id{get;set;}
    }
