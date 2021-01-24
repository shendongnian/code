	[XmlType(TypeName= "CanonicalUser")]
	public class Grantee
	{
		[XmlElement(ElementName = "ID", IsNullable = true)]
		public string ID { get; set; }
		
		[XmlElement(ElementName = "URI", IsNullable = true)]
		public string URI { get; set; }
		
		[XmlElement(ElementName = "DisplayName", IsNullable = true)]
		public string DisplayName { get; set; }
	}
