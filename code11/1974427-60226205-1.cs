    [XmlRoot(ElementName="option")]
	public class Option {
		[XmlElement(ElementName="id")]
		public string Id { get; set; }
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
	}
	[XmlRoot(ElementName="data")]
	public class Data {
		[XmlElement(ElementName="option")]
		public List<Option> Option { get; set; }
		[XmlAttribute(AttributeName="label")]
		public string Label { get; set; }
		[XmlAttribute(AttributeName="min")]
		public string Min { get; set; }
		[XmlAttribute(AttributeName="max")]
		public string Max { get; set; }
	}
	[XmlRoot(ElementName="root")]
	public class Root {
		[XmlElement(ElementName="data")]
		public Data Data { get; set; }
	}
