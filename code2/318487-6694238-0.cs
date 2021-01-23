    using System.Xml.Serialization;
    
    namespace DeserializeExample
    {
    	[XmlRoot("root")]
    	public class BillingItemResult
    	{
    		[XmlElement("item")]
    		public BillingItems Items { get; set; }
    	}
    }
