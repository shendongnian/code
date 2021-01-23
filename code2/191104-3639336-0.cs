    public static string ToFormattedString<TKey, TValue>(this IDictionary<TKey, TValue> dic, string format, string separator)
    {
    	return String.Join(
    		!String.IsNullOrEmpty(separator) ? separator : " ",
    		dic.Select(p => String.Format(
    			!String.IsNullOrEmpty(format) ? format : "{0}='{1}'",
    			p.Key, p.Value)));
    }
