	public static XElement ToXElement(this object obj)
	{
		XDocument xDoc = new XDocument();
		var xmlSerializer = new XmlSerializer(obj.GetType());
		using (var xmlWriter = xDoc.CreateWriter())
			xmlSerializer.Serialize(xmlWriter, obj);
		return ((XElement)xDoc.FirstNode);
	}
	public static T FromXElement<T>(this XElement xElement)
	{
		var xmlSerializer = new XmlSerializer(typeof(T));
		return (T)xmlSerializer.Deserialize(xElement.Document.CreateReader());
	}
