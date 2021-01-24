        [XmlRoot("root", Namespace = "")]
		public class Personal
		{
			[XmlElement("x_Name", Namespace = "")]
			public string Name { get; set; }
			[XmlElement("x_Age", Namespace = "")]
			public string Age { get; set; }
		}
		[XmlRoot("root", Namespace = "")]
		public class Contact
		{
			[XmlElement("x_country", Namespace = "")]
			public string Country { get; set; }
			[XmlElement("x_zip", Namespace = "")]
			public string Zip { get; set; }
		}
    
