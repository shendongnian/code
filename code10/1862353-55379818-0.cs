void Main()
{
	var result = MyHtml.DescriptionFor2<Test>((t) => t.Member);
	Console.WriteLine(result);
}
public class Test
{
	[Description("This is a test member")]
	public string Member { get; set; }
}
public static class MyHtml
{
	public static string DescriptionFor2<T>(Expression<Func<T, dynamic>> expression)
	{
		var result = string.Empty;
		var property = typeof(T).GetProperty((expression.Body as MemberExpression).Member.Name);
	    if (property != null)
	    {
	        var attr = property
	                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
	                    .Cast<DescriptionAttribute>()
	                    .FirstOrDefault();
	
	        result = attr?.Description ?? string.Empty;
	    }
	
	    return result;
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
var result = MyHtml.DescriptionFor2<Test, string>((t) => t.Member);
