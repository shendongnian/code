	void Main()
	{
		var s = new XmlSerializer(typeof(OlpData));
		using (var t = new StreamWriter("code.xml"))
		{
			var xml = new OlpData { Resources = new[] { new Resource() } };
			s.Serialize(t, xml);
		}
	}
	
	[XmlRoot("OLPData")]
	public partial class OlpData
	{
		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = XmlSchema.InstanceNamespace)]
		public string attr = @"C:\Program Files\Dassault Systemes\B19\intel_a\startup\Olp\XSchemas\Upload.xsd";
		[XmlElement("Resource")]
		public Resource[] Resources;
	}
	
	public partial class Resource
	{
	}
