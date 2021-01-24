    [XmlRoot(ElementName="partition_id", Namespace="http://www.collegenet.com/r25")]
    public class Partition_id {
    	[XmlAttribute(AttributeName="href", Namespace="http://www.w3.org/1999/xlink")]
    	public string Href { get; set; }
    	[XmlText]
    	public string Text { get; set; }
    }
    
    [XmlRoot(ElementName="space", Namespace="http://www.collegenet.com/r25")]
    public class Space {
    	[XmlElement(ElementName="space_id", Namespace="http://www.collegenet.com/r25")]
    	public string Space_id { get; set; }
    	[XmlElement(ElementName="space_name", Namespace="http://www.collegenet.com/r25")]
    	public string Space_name { get; set; }
    	[XmlElement(ElementName="formal_name", Namespace="http://www.collegenet.com/r25")]
    	public string Formal_name { get; set; }
    	[XmlElement(ElementName="partition_id", Namespace="http://www.collegenet.com/r25")]
    	public Partition_id Partition_id { get; set; }
    	[XmlElement(ElementName="last_mod_dt", Namespace="http://www.collegenet.com/r25")]
    	public string Last_mod_dt { get; set; }
    	[XmlAttribute(AttributeName="crc")]
    	public string Crc { get; set; }
    	[XmlAttribute(AttributeName="status")]
    	public string Status { get; set; }
    	[XmlAttribute(AttributeName="href", Namespace="http://www.w3.org/1999/xlink")]
    	public string Href { get; set; }
    }
    
    [XmlRoot(ElementName="spaces", Namespace="http://www.collegenet.com/r25")]
    public class Spaces {
    	[XmlElement(ElementName="space", Namespace="http://www.collegenet.com/r25")]
    	public Space Space { get; set; }
    	[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
    	public string Xsi { get; set; }
    	[XmlAttribute(AttributeName="xl", Namespace="http://www.w3.org/2000/xmlns/")]
    	public string Xl { get; set; }
    	[XmlAttribute(AttributeName="r25", Namespace="http://www.w3.org/2000/xmlns/")]
    	public string R25 { get; set; }
    	[XmlAttribute(AttributeName="pubdate")]
    	public string Pubdate { get; set; }
    	[XmlAttribute(AttributeName="engine")]
    	public string Engine { get; set; }
    }
