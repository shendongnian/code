	public static string MethodCallExpressionRepresentation(this LambdaExpression expr)
	{
		var expression = (MethodCallExpression)expr.Body;
		var arguments = string.Join(", ", expression.Arguments.OfType<MemberExpression>().Select(x => {
			var tempInstance = ((ConstantExpression)x.Expression).Value;
			var fieldInfo = (FieldInfo)x.Member;
			return "\"" + fieldInfo.GetValue(tempInstance).ToString() + "\"";
		}).ToArray());
		return expression.Object.Type.FullName + "." + expression.Method.Name + "(" + arguments + ")";
	}
