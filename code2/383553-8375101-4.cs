	public static XElement ToXElement<T>(this object obj)
	{
		using (var memoryStream = new MemoryStream())
		{
			using (TextWriter streamWriter = new StreamWriter(memoryStream))
			{
				var xmlSerializer = new XmlSerializer(typeof(T));
				xmlSerializer.Serialize(streamWriter, obj);
				return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
			}
		}
	}
	public static T FromXElement<T>(this XElement xElement)
	{
			var xmlSerializer = new XmlSerializer(typeof(T));
			return (T)xmlSerializer.Deserialize(xElement.CreateReader());
	}
