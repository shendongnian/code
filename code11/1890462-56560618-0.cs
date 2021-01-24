    [XmlRoot(ElementName="Access")]
	public class Access {
		[XmlElement(ElementName="User")]
		public List<string> User { get; set; }
		[XmlElement(ElementName="Role")]
		public List<string> Role { get; set; }
	}
	[XmlRoot(ElementName="MyClass")]
	public class MyClass {
		[XmlElement(ElementName="Access")]
		public Access Access { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}
