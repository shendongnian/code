	public class MyClass
	{
		public MyClass()
		{
			SpecialtyCd = string.Empty;
			DoctorUid = string.Empty;
		}
		[XmlAttribute]
		public string SpecialtyCd { get; set; }
		[XmlAttribute]
		public string DoctorUid { get; set; }
		[XmlIgnore]
		public DateTime? ValidFrom { get; set; }
		[XmlIgnore]
		public DateTime? ValidUntil { get; set; }
		[XmlAttribute("ValidUntil")]
		public string ValidUntilString
		{
			get { return ValidUntil.HasValue ? ValidUntil.Value.ToString() : null; }
			set
			{
				ValidUntil = value== null ?  (DateTime?) null : DateTime.Parse(value) ;
			}
		}
		[XmlAttribute("ValidFrom")]
		public string ValidFromString
		{
			get { return ValidFrom.HasValue ? ValidFrom.Value.ToString() : null; }
			set
			{
				ValidFrom = value== null ?  (DateTime?) null : DateTime.Parse(value) ;
			}
		}
	}
