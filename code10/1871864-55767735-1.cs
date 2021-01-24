	public class Portfolio
	{
		public string Name {get; set;}
		
		[JsonConverter(typeof(PositionDictionaryConverter))]
		public Dictionary<string,Position> Positions {get; set;}
	}
