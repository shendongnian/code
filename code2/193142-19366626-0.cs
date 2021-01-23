	public static partial class StringExtensions {
		public static String InvertCase(this String t) {
			Func<char, String> selector=
				c => (char.IsUpper(c)?char.ToLower(c):char.ToUpper(c)).ToString();
			return t.Select(selector).Aggregate(String.Concat);
		}
	}
