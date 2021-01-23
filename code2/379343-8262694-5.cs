	using (XmlTextWriter writer =new XmlTextWriter("test.xml", Encoding.UTF8))
	{
		writer.WriteStartDocument();
		writer.WriteStartElement("Test");
		var escaped = XmlTextEncoder.Encode("hello \xb world");
		writer.WriteString(escaped);
		writer.WriteEndElement();
		writer.WriteEndDocument();
	}
	var doc = XDocument.Load("test.xml");
	var val = doc.XPathSelectElement("//Test").Value;
