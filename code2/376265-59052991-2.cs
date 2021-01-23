		public static string RemoveInvalidXmlChars(string content)
		{
			if (content.Any(ch => !System.Xml.XmlConvert.IsXmlChar(ch)))
				return new string(content.Where(ch => System.Xml.XmlConvert.IsXmlChar(ch)).ToArray());
			else
				return content;
		}
