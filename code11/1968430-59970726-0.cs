    public class C
    {
    	[XmlAttribute]
    	public string Attr { get; set; }
    }
    public class B
    {
    	[XmlElement]
    	public string B1 { get; set; }
    	[XmlElement]
    	public string B2 { get; set; }
    	[XmlElement]
    	public string B3 { get; set; }
    }
    [XmlRoot]
    public class A
    {
    	[XmlElement("C")]
    	public C[] Cs { get; set; }
    	[XmlElement("B")]
    	public B B { get; set; }
    
    	[XmlIgnore()]
    	public string B1 => B.B1;
    	[XmlIgnore()]
    	public string B2 => B.B2;
    	[XmlIgnore()]
    	public string B3 => B.B3;
    }
