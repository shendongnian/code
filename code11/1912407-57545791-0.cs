	public class ZendeskError
	{
		[JsonProperty("details")]
		public Dictionary<string, List<PropertyFailureInformation>> ErrorDetails { get; set; }
		[JsonProperty("description")]
		public string ErrorDescription { get; set; }
		[JsonProperty("error")]
		public string Error { get; set; }
	}
	public class PropertyFailureInformation
	{
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("error")]
		public string Error { get; set; }
	}
