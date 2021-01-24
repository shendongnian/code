    [XmlRoot(ElementName="MYAPI")]
    public class MYAPI 
    {
    	[XmlElement(ElementName="MySite")]
    	public List<MySite> MySite { get; set; }
    	
    	[XmlElement(ElementName="SomeOtherSite")]
    	public SomeOtherSite SomeOtherSite { get; set; }
    }
    
    public class MySite 
    {
    	[XmlElement(ElementName="Name")]
    	public string Name { get; set; }
    	
    	[XmlElement(ElementName="URL")]
    	public string URL { get; set; }
    	
    	[XmlElement(ElementName="SecondName")]
    	public string SecondName { get; set; }
    	
    	[XmlAttribute(AttributeName="Resource")]
    	public string Resource { get; set; }
    }
