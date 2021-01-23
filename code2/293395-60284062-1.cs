C#
public static bool TryGetDefaultValue<TSource, TResult>(this TSource _, Expression<Func<TSource, TResult>> expression, out TResult result)
{
	if (((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(DefaultValueAttribute)) is DefaultValueAttribute attribute)
	{
		result = (TResult)attribute.Value;
		return true;
	}
	result = default;
	return false;
}
Alternatively, you're OK with the default value being returned if the attribute was not found, use this:
C#
public static TResult GetDefaultValue<TSource, TResult>(this TSource _, Expression<Func<TSource, TResult>> expression)
{
	if (((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(DefaultValueAttribute)) is DefaultValueAttribute attribute)
	{
		return (TResult)attribute.Value;
	}
	return default;
}
You could also modify it to throw an exception if the attribute wasn't found.
