	[XmlRoot(ElementName = "AccessControlPolicy", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/")]
	public class AccessControlPolicy
	{
		[XmlElement(ElementName = "Owner", IsNullable = true)]
		public Owner Owner { get; set; }
	
    	[XmlElement(ElementName = "AccessControlList", IsNullable = true)]
		public AccessControlList AccessControlList { get; set; }
	}
