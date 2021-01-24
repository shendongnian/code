lang-csharp
static string GetPath<T>(Expression<Func<T>> prop)
{
	var body = prop.Body as System.Linq.Expressions.MemberExpression;
	if (body is null)
	{
		return null;
	}
	string res = body.Member.Name;
	MemberExpression expr = body;
	while ((expr = (expr.Expression as MemberExpression)) != null)
	{
		if (expr.Member is FieldInfo fi)
		{
			res = fi.FieldType.Name + "." + res;
		}
		else if (expr.Member is PropertyInfo pi)
		{
			res = pi.PropertyType.Name + "." + res;
		}
	}
	return res;	
}
