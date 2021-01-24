    [XmlRoot(ElementName = "Segment")]
    public class FooSegment
    {
    	[XmlElement(ElementName = "Id", Namespace = "http://tempuri.org/foo")]
    	public List<string> Id { get; set; }
    	[XmlAttribute(AttributeName = "d4p1", Namespace = "http://www.w3.org/2000/xmlns/")]
    	public string D4p1 { get; set; }
    	[XmlAttribute(AttributeName = "type", Namespace = "http://tempuri.org/body")]
    	public string Type { get; set; }
    }
    
    [XmlRoot(ElementName = "Segment")]
    public class BarSegment
    {
    	[XmlElement(ElementName = "Id", Namespace = "http://tempuri.org/bar")]
    	public List<string> Id { get; set; }
    	[XmlAttribute(AttributeName = "d4p1", Namespace = "http://www.w3.org/2000/xmlns/")]
    	public string D4p1 { get; set; }
    	[XmlAttribute(AttributeName = "type", Namespace = "http://tempuri.org/body")]
    	public string Type { get; set; }
    }
