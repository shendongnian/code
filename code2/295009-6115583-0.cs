	public static IEnumerable<XNode> ParseXml(string xml)
	{
		var settings = new XmlReaderSettings
		{
			ConformanceLevel = ConformanceLevel.Fragment,
			IgnoreWhitespace = true
		};
		using (var stringReader = new StringReader(xml))
		using (var xmlReader = XmlReader.Create(stringReader, settings))
		{
			xmlReader.MoveToContent();
			while (xmlReader.ReadState != ReadState.EndOfFile)
			{
				yield return XNode.ReadFrom(xmlReader);
			}
		}
	}
