	public class Owner
	{
		[XmlElement(ElementName = "ID",  IsNullable = true)]
		public string ID { get; set; }
		[XmlElement(ElementName = "DisplayName", IsNullable = true)]
		public string DisplayName { get; set; }
	}	
