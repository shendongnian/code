	public class Value
	{
		public string documentType { get; set; }
		public string SONumber { get; set; }
		
		[JsonConverter(typeof(EmbeddedLiteralConverter<List<SalesLine>>))]
		public List<SalesLine> SalesLines { get; set; }
	}
