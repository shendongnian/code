    // Class-Class version
	public static U? Map<T,U>(this T? item, Func<T, U?> formatClosure)
	where T : class
	where U : class
		=> (item != null)
			? formatClosure(item)
			: null;
    // Struct-Struct version
	public static U? Map<T,U>(this T? item, Func<T, U?> formatClosure)
	where T : struct
	where U : struct
		=> item.HasValue
			? formatClosure(item.Value)
			: null;
    // Class-Struct version
	public static U? Map<T,U>(this T? item, Func<T, U?> formatClosure)
	where T : class
	where U : struct
		=> (item != null)
			? formatClosure(item)
			: null;
    // Struct-Class version
	public static U? Map<T,U>(this T? item, Func<T, U?> formatClosure)
	where T : struct
	where U : class
		=> item.HasValue
			? formatClosure(item.Value)
			: null;
