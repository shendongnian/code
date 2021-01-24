    [Serializable]
	public class A
	{
		[XmlArray("Content")]
        [XmlArrayItem("Some")]
		public List<B> SomeNames { get; set; } = new List<B>();
	}
	public class B
	{
		[XmlAttribute(AttributeName = "element")]
		public int X { get; set; }
	}
    public static void XmlSerialize()
    {
    	var a = new A {SomeNames = new List<B> {new B() {X = 5}}};
    	var serializer = new XmlSerializer(typeof(A));
    	var settings = new XmlWriterSettings() {Indent = true};
    	using var stream = XmlWriter.Create("serialized.xml", settings);
    	serializer.Serialize(stream, a);
    }
