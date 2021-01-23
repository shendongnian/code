    public static string ToString<TEnum>(this IEnumerable<TEnum> source,
    							string separator) where TEnum : struct
    {
    	if (!typeof(TEnum).IsEnum) throw new InvalidOperationException("TEnum must be an enumeration type. ");
    	if (source == null || separator == null) throw new ArgumentNullException();
    	var strings = source.Where(e => Enum.IsDefined(typeof(TEnum), e)).Select(n => Enum.GetName(typeof(TEnum), n));
    	return string.Join(separator, strings);
    }
