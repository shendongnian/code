    	[JsonObject]
	public class MyObject {
		[JsonConverter(typeof(Int32Converter))]
		public Dictionary<string, object> Properties { get; set; }
	}
