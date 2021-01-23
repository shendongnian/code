	public class SomeClassThatDependsOnCurrentTime
	{
		internal Func<DateTime> NowGenerator { get; set; }
		public SomeClassThatDependsOnCurrentTime()
		{
			// default in constructor to return DateTime.Now
			NowGenerator = () => DateTime.Now;
		}
		public bool IsAfterMarketClose()
		{
			// call the generator instead of DateTime.Now directly...
			return NowGenerator().TimeOfDay > new TimeSpan(16, 0, 0);
		}
	}
