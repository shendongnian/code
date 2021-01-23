	private static class ParseDelegateStore<T>
	{
		public static ParseDelegate<T> Parse;
		public static TryParseDelegate<T> TryParse;
	}
	private delegate T ParseDelegate<T>(string s);
	private delegate bool TryParseDelegate<T>(string s, out T result);
	public static T Parse<T>(string s)
	{
		ParseDelegate<T> parse = ParseDelegateStore<T>.Parse;
		if (parse == null)
		{
			parse = (ParseDelegate<T>)Delegate.CreateDelegate(typeof(ParseDelegate<T>), typeof(T), "Parse", true);
			ParseDelegateStore<T>.Parse = parse;
		}
		return parse(s);
	}
	public static bool TryParse<T>(string s, out T result)
	{
		TryParseDelegate<T> tryParse = ParseDelegateStore<T>.TryParse;
		if (tryParse == null)
		{
			tryParse = (TryParseDelegate<T>)Delegate.CreateDelegate(typeof(TryParseDelegate<T>), typeof(T), "TryParse", true);
				ParseDelegateStore<T>.TryParse = tryParse;
		}
		return tryParse(s, out result);
	}
