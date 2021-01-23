    [Serializable]
    public class MyClass
    {
    	const string TimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'sszzz";
    
    	[XmlElement("Time")]
    	public string TimeString { get{return Time.ToString(TimeFormat);} set{Time = DateTimeOffset.ParseExact(value, TimeFormat, null);} }
    	
    	[XmlIgnore]
    	public DateTimeOffset Time { get; set; }
    }
