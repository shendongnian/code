		using(MemoryStream stream = new MemoryStream())
		using(StreamReader streamReader = new StreamReader(stream))
		using(XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
		{
			writer.WriteStartDocument(true);
			writer.WriteStartElement("a");
			
			try 
			{
				throw new Exception();
			}
			catch 
			{
                // This line makes de magic: ending the document
                // avoids the issue mentioned by @NigelTouch
				writer.WriteEndDocument();
				writer.Flush();
				stream.SetLength(0);
			}
			
			
			writer.WriteStartDocument(true);
			writer.WriteStartElement("b");
			writer.WriteEndElement();
			writer.Flush();
			
			stream.Position = 0;
			
			Console.WriteLine(streamReader.ReadToEnd());
			
		}
