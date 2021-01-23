	public static TResult WhenNotNull<T, TResult>(this T subject, Func<T, TResult> expression)
		where T : class
	{
		if (subject == null) return default(TResult);
		return expression(subject);
	}
	public static TResult WhenNotNull<T, TResult>(
		this T subject, Func<T, TResult> expression,
		TResult defaultValue)
		where T : class
	{
		if (subject == null) return defaultValue;
		return expression(subject);
	}
	public static void WhenNotNull<T>(this T subject, Action<T> expression)
		where T : class
	{
		if (subject != null)
		{
			expression(subject);
		}
	}
	public static TResult WhenNotNull<T, TResult>(
		this Nullable<T> subject, 
		Func<Nullable<T>, TResult> expression)
		where T : struct
	{
		if (!subject.HasValue) return default(TResult);
		return expression(subject);
	}
