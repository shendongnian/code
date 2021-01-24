	public class RootObject
	{
		[JsonProperty("rates")]
		public Dictionary<string, Dictionary<string, double>> Rates { get; set; }
		[JsonProperty("start_at")]
		public DateTimeOffset StartAt { get; set; }
		[JsonProperty("base")]
		public string Base { get; set; }
		[JsonProperty("end_at")]
		public DateTimeOffset EndAt { get; set; }
	}
