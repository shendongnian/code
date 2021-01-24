	class Item
	{
		public string Email { get; set; }
		public int Timestamp { get; set; }
		public string Event { get; set; }
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Category { get; set; }
	}
