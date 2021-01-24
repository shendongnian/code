	[XmlRoot("root")]
	public class Root
	{
		[XmlArray("foos")]
		[XmlArrayItem("foo")]
		public List<Foo> foos { get; set; }              
	}
	[XmlRoot("foo")]
	public class Foo
	{
		[XmlElement("fooName")]
		public string FooName { get; set; }
		[XmlElement("fooId")]
		public string FooId { get; set; }
		[XmlElement("fooDate")]
		public string FooDate { get; set; }               
		
		[XmlText]
		public string Value { get; set; }
	}
