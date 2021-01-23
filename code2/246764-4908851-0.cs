	public static class Utilities
	{
		public static object GetSelectList<TEnum>(this TEnum? obj)
			where TEnum : struct 
		{
			var values = from TEnum x in Enum.GetValues(typeof(TEnum))
						 select new { Text = x.ToString(), Value = x };
			return values;
		}
	}
