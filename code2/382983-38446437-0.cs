    [Serializable]
	public class AppTelecommunicationsNumber : AppContactMechanism {
		public int AreaCode { get; set; }
		public string ContactNumber { get; set; }
		public int? CountryCode { get; set; }
		public string Extention { get; set; }
	}
