    XmlSerializer serializer = new XmlSerializer(typeof(Animal[]), new XmlRootAttribute("Animals"));
	public class Animal
	{
		[XmlElement]
		public string Name;
		[XmlElement]
		public string Type;
	}
