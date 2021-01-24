	public class Value
	{
		[JsonProperty("$type")]
		public string Type { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
	public class Properties
	{
		[JsonProperty("$type")]
		public string Type { get; set; }
		[JsonProperty("$values")]
		public List<Value> Values { get; set; }
	}
	public class ActivityModel
	{
		[JsonProperty("$type")]
		public string Type { get; set; }
		public Properties Properties { get; set; }
	}
