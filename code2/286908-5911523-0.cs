    public static class NumberStringExtension
	{
	
		public static bool IsNumber(this string value)
		{
			int i = 0;
			return int.TryParse(value, out i));
		}
	}
