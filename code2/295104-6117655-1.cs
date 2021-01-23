    public static IEnumerable<T> GetAllValues<T>() where T : struct
    {
    	if (!typeof(T).IsEnum) throw new ArgumentException("Generic argument is not an enumeration type");
    	int maxEnumValue = (1 << Enum.GetValues(typeof(T)).Length) - 1;
    	return Enumerable.Range(0, maxEnumValue).Cast<T>();
    }
