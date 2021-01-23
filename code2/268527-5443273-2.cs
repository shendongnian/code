    [XmlType("REQUESTS")]  
    public class Requests
    {
        [XmlElement(ElementName="ACTION")]
        public string Action { get; set; }
        [XmlElement(ElementName="META")]
        public Meta MetaType { get; set; }
        ...
    
    }
    
    public class Meta
    {
    
        [XmlElement(ElementName="MERCHANTID")]
        public string MerchantId { get; set; }
        ...
    }
