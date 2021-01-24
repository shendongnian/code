	internal class Translation
	{
		public string Name { get; set; }
		[JsonExtensionData]
		public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
	}
