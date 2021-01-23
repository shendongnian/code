	XmlWriterSettings xmlWriterSettings = new XmlWriterSettings 
	{ 
		Indent = true, 
		OmitXmlDeclaration = false, 
		Encoding = Encoding.UTF8 
	};
	using (MemoryStream memoryStream = new MemoryStream() )
	using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
	{	
		System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
		x.Serialize(xmlWriter, p);
		// we just output back to the console for this demo.
		memoryStream.Position = 0; // rewind the stream before reading back.
		using( StreamReader sr = new StreamReader(memoryStream))
		{
			Console.WriteLine(sr.ReadToEnd());
		} // note memory stream disposed by StreamReaders Dispose()
	}
