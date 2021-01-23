	private static T Deserialize<T>(string xml)
	{
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
		return (T)serializer.Deserialize(new StringReader(xml));
	}
