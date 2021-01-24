	public class Grant
	{
		[XmlElement(ElementName = "Grantee",  IsNullable = true)]
		public Grantee Grantee { get; set; }
		[XmlElement(ElementName = "Permission", IsNullable = true)]
		public string Permission { get; set; }
	}
