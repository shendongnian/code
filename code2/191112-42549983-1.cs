    public static class DictionaryExtensions
	{
		public static string ToFormatString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string format = null)
		{
			format = string.IsNullOrEmpty(format) ? "{0}='{1}'" : format;
			return string.Join(", ", dictionary.Select(kv => string.Format(format, kv.Key, kv.Value)));
		}
	}
