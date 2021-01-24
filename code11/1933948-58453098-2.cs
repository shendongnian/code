	public class Tag : IXmlSerializable
	{
		public bool HasExport { get; set; }
		public bool HasDelete { get; set; }
		public XmlSchema GetSchema() => null;
		public void WriteXml(XmlWriter writer)
		{
			if (HasExport)
				writer.WriteElementString("Export", null);
			if (HasDelete)
				writer.WriteElementString("Delete", null);
		}
		public void ReadXml(XmlReader reader)
		{
			// TODO...
		}
	}
