void Main()
{
	Console.WriteLine(MyHtml.DescriptionFor2<Test>((t) => t.StringMember));
	Console.WriteLine(MyHtml.DescriptionFor2<Test>((t) => t.BooleanMember));
	Console.WriteLine(MyHtml.DescriptionFor2<Test>((t) => t.IntegerMember));
}
public class Test
{
	[Description("This is a string member")]
	public string StringMember { get; set; }
	[Description("This is a boolean member")]
	public bool BooleanMember { get; set; }
	[Description("This is a integer member")]
	public int IntegerMember { get; set; }
}
public static class MyHtml
{
	public static string DescriptionFor2<T>(Expression<Func<T, dynamic>> expression)
	{
		var result = string.Empty;
		var member = GetMemberExpression(expression)?.Member?.Name;
		if (member != null)
		{
			var property = typeof(T).GetProperty(member);
		    if (property != null)
		    {
		        var attr = property
		                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
		                    .Cast<DescriptionAttribute>()
		                    .FirstOrDefault();
		
		        result = attr?.Description ?? string.Empty;
		    }
		}
	
	    return result;
	}
	
	private static MemberExpression GetMemberExpression<T>(Expression<Func<T, dynamic>> expression)
	{
	    var member = expression.Body as MemberExpression;
	    var unary = expression.Body as UnaryExpression;
	    return member ?? (unary != null ? unary.Operand as MemberExpression : null);
	}
}
public class DescriptionAttribute : Attribute
{
	public string Description { get; set; }
	
	public DescriptionAttribute(string description)
	{
		Description = description;
	}
}
It involves getting the body of the expression as a member and using its name to resolve the property on the object. The `dynamic` data type is used to get rid of the second type parameter, however you can also define it explicitly for better compile-time error catching:
public static string DescriptionFor2<T, U>(Expression<Func<T, U>> expression)
and calling it:
MyHtml.DescriptionFor2<Test, string>((t) => t.StringMember);
MyHtml.DescriptionFor2<Test, bool>((t) => t.BooleanMember);
MyHtml.DescriptionFor2<Test, int>((t) => t.IntegerMember);
EDIT: edited answer because initial solution did not work for value types, see https://stackoverflow.com/questions/12975373/expression-for-type-members-results-in-different-expressions-memberexpression
