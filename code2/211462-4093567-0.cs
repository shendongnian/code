    public static String Join<T>(this IEnumerable<T> enumerable, string seperator)
    {
    	var nullRepresentation = "";
    	var enumerableAsStrings = enumerable.Select(a => a == null ? nullRepresentation : a.ToString()).ToArray();
    	return string.Join(seperator, enumerableAsStrings);
    }
    
    public static String Join<T>(this IEnumerable<T> enumerable)
    {
    	return enumerable.Join(",");
    }
