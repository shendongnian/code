	public static class SerializerHelper<T>
	{
		public static string Serialize(T myobject)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringWriter stringWriter = new StringWriter();
			xmlSerializer.Serialize(stringWriter, myobject);
			string xml = stringWriter.ToString();
			return xml;
		}
		public static T Deserialize(string xml)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringReader stringReader = new StringReader(xml);
			return (T)xmlSerializer.Deserialize(stringReader);
		}
	}
