	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://someurl")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://someurl", IsNullable = false)]
	public partial class MyItem
	{
		[System.Xml.Serialization.XmlTextAttribute]
		public string Value { get; set; }
	}
