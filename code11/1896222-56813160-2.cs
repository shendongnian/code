	XmlWriterSettings settings = new XmlWriterSettings { Indent = true  };
	StringBuilder stringBuilder = new StringBuilder();
	using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
	{
		xmlWriter.WriteStartElement("myroot"); // Writes <myroot>
		var serializer = new XmlSerializer(typeof(Parts));
		var parts = new Parts();
		serializer.Serialize(xmlWriter, parts);
		xmlWriter.WriteEndElement(); // Writes </myroot>
	}
