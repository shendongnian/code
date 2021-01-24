	public static class MyExtensions
	{
		public static string ToHappyString(this double value)
		{
			return value.ToString("0.##", CultureInfo.InvariantCulture);
		}
	}
	
