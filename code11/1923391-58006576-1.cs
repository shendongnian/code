	public class MyJsonClass
	{
		public string COID { get; set; }
		public string CLIENTID { get; set; }
		[JsonConverter(typeof(CustomDateTimeConverter))]
		public DateTime? BIRTHDAY { get; set; }
	}
