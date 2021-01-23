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
