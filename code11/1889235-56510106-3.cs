	[JsonConverter(typeof(ObjectToArrayConverter<ArrayWrapper>))]
	public struct ArrayWrapper
	{
		[JsonProperty(Order = 1)]
		public int Item0 { get; set; }
		[JsonProperty(Order = 2)]
		public int Item1 { get; set; }
	}
