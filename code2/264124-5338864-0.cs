	public static class StringExtensions
	{
		public static string NullSafe(this string s)
		{
			return s ?? string.Empty;
		}
	}
