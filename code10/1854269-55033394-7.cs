	public void Serialze(string filename)
	{
		XmlSerializer _xmlSerializer = new XmlSerializer(typeof(SchematicExport));
		// FIXED ensure the file is closed.
		using (var _textWriter = new StreamWriter(filename))
		{
			_xmlSerializer.Serialize(_textWriter, this);
		}
	}
