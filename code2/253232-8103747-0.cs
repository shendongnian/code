    [XmlRoot("LogMessage"]
    public class LogMessage
    {
    	[XmlElement("avantlog")]
    	public LogEventType AvantLog {get; set;}
    }
    
    public class LogEventType
    {
    	[XmlArray("context")]
    	[XmlArrayItem("severity")]
    	public string[] Severity {get; set;}
    }
