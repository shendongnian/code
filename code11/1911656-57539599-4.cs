		public static string GetSoapBodyXml<T>(this T obj, XmlSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, ConformanceLevel = ConformanceLevel.Fragment }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
				{
	                xmlWriter.WriteWhitespace(""); // Hack to prevent an error about WriteStartDocument getting called for ConformanceLevel.Fragment
                    (serializer ?? GetDefaultSoapSerializer(obj.GetType())).Serialize(xmlWriter, obj);
				}
                return textWriter.ToString();
            }
        }
