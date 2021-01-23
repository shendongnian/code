	[XmlRoot("Farm")]
	public class Farm
	{
		[XmlElement("Person", typeof(Person))]
		[XmlElement("Dog", typeof(Dog))]
		public List<Animal> Items { get; set; }
	}
	
