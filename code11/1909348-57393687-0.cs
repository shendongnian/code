    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
    	[XmlElement(ElementName = "Header")]
    	public Header Header { get; set; }
    	[XmlElement(ElementName = "Body")]
    	public Body Body { get; set; }
    	[XmlAttribute(AttributeName = "soapenv")]
    	public string Soapenv { get; set; }
    	[XmlAttribute(AttributeName = "q0")]
    	public string Q0 { get; set; }
    	[XmlAttribute(AttributeName = "xsd")]
    	public string Xsd { get; set; }
    	[XmlAttribute(AttributeName = "xsi")]
    	public string Xsi { get; set; }
    }
    	
    [XmlRoot(ElementName = "Header", Namespace = http://schemas.xmlsoap.org/soap/envelope/")]
    public class Header
    {
    	[XmlElement(ElementName = "LoginScopeHeader")]
    	public LoginScopeHeader LoginScopeHeader { get; set; }
    	[XmlElement(ElementName = "SessionHeader")]
    	public SessionHeader SessionHeader { get; set; }
    }
    
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
    	[XmlElement(ElementName = "PersonSet")]
    	public PersonSet PersonSet { get; set; }
    }
