	public static string Beautify(XmlDocument doc)
	{
		string xmlString = null;
		using (MemoryStream ms = new MemoryStream()) {
			XmlWriterSettings settings = new XmlWriterSettings {
				Encoding = new UTF8Encoding(false),
				Indent = true,
				IndentChars = "  ",
				NewLineChars = "\r\n",
				NewLineHandling = NewLineHandling.Replace
			};
			using (XmlWriter writer = XmlWriter.Create(ms, settings)) {
				doc.Save(writer);
			}
			xmlString = Encoding.UTF8.GetString(ms.ToArray());
		}
		return xmlString;
	}
