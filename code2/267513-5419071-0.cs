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
		[XmlAttribute]
		public DateTime? ValidFrom { get; set; }
		[XmlAttribute]
		public DateTime? ValidUntil { get; set; }
	}
