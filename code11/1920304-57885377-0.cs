c#
static MethodInfo GetSetterForX(Expression<Func<double>> expression)
{
	var body = expression.Body;
	var operand = body as MemberExpression;
	var propertyInfo = (PropertyInfo)(operand.Member);
	var setter = propertyInfo.GetSetMethod(true);
	return setter;
}
public static void Main()
{
	var testObject = new TestObject();
	var setter = GetSetterForX(() => testObject.X);
	setter.Invoke(testObject, new object[]{5});
	Debug.Assert(testObject.X == 5);
}
Fiddle : https://dotnetfiddle.net/CHJGbk
