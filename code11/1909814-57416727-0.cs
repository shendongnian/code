    [XmlRootAttribute(Namespace = "http://abc.def.schema", IsNullable = false, ElementName = "LoginResult")]
    public class LoginResult
    {
    	[XmlElement(Namespace ="")]
    	public int sessionId { get; set; }
    
    	[XmlElement(Namespace = "")]
    	public string organizationName { get; set; }
    
         ..... some more properties
    }
