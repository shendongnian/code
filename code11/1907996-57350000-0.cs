	public static class XmlReaderExtensions
	{
        public static IEnumerable<XmlReader> ReadRoots(this XmlReader reader)
        {
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					using (var subReader = reader.ReadSubtree())
						yield return subReader;
				}
			}
        }
		
		public static void SplitDocumentFragments(Stream stream, Func<int, string> makeFileName, Action<string, IXmlLineInfo> onFileWriting, Action<string, IXmlLineInfo> onFileWritten)
		{
			using (var textReader = new StreamReader(stream, Encoding.UTF8, true, 4096, true))
			{
				SplitDocumentFragments(textReader, makeFileName, onFileWriting, onFileWritten);
			}
		}
		
		public static void SplitDocumentFragments(TextReader textReader, Func<int, string> makeFileName, Action<string, IXmlLineInfo> onFileWriting, Action<string, IXmlLineInfo> onFileWritten)
		{
			if (textReader == null || makeFileName == null)
				throw new ArgumentNullException();
		    var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, CloseInput = false };
			using (var xmlReader = XmlReader.Create(textReader, settings))
			{
				var lineInfo = xmlReader as IXmlLineInfo;
				var index = 0;
				
				foreach (var reader in xmlReader.ReadRoots())
				{
					var outputName = makeFileName(index);
					reader.MoveToContent();
					if (onFileWriting != null)
						onFileWriting(outputName, lineInfo);
					using(var writer = XmlWriter.Create(outputName))
					{
						writer.WriteNode(reader, true);
					}
					index++;
					if (onFileWritten != null)
						onFileWritten(outputName, lineInfo);
				}
			}
		}
	}
