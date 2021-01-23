	var settings = new XmlReaderSettings{ConformanceLevel = ConformanceLevel.Fragment};
	var reader = XmlReader.Create(stream, settings);
	while(reader.Read())
	{
		while(reader.NodeType != XmlNodeType.None)
		{
			if(reader.NodeType == XmlNodeType.XmlDeclaration)
			{
				reader.Skip();
				continue;
			}
			XNode node = XNode.ReadFrom(reader);
		}
	}
