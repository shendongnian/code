    public class SnData
	{
		public string Value1 { get; set; }
		public string Value2 { get; set; }
		public Result Result { get; set; }
	}
	public class Result
	{
		public Stats Stats { get; set; }
	}
	public class Stats
	{
		public int Count { get; set; }
	}
