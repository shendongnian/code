    public static class StringFunctions
    {
    	public static bool IsGreaterThan(this string left, string right) => string.Compare(left, right) > 0;
    	public static bool IsGreaterThanOrEqual(this string left, string right) => string.Compare(left, right) >= 0;
    	public static bool IsLessThan(this string left, string right) => string.Compare(left, right) < 0;
    	public static bool IsLessThanOrEqual(this string left, string right) => string.Compare(left, right) <= 0;
    	public static ModelBuilder RegisterStringFunctions(this ModelBuilder modelBuilder) => modelBuilder
    		.RegisterFunction(nameof(IsGreaterThan), ExpressionType.GreaterThan)
    		.RegisterFunction(nameof(IsGreaterThanOrEqual), ExpressionType.GreaterThanOrEqual)
    		.RegisterFunction(nameof(IsLessThan), ExpressionType.LessThan)
    		.RegisterFunction(nameof(IsLessThanOrEqual), ExpressionType.LessThanOrEqual);
    	static ModelBuilder RegisterFunction(this ModelBuilder modelBuilder, string name, ExpressionType type)
    	{
    		var method = typeof(StringFunctions).GetMethod(name, new[] { typeof(string), typeof(string) });
    		modelBuilder.HasDbFunction(method).HasTranslation(parameters =>
    		{
    			var left = parameters.ElementAt(0);
    			var right = parameters.ElementAt(1);
    			// EF Core 2.x
    			return Expression.MakeBinary(type, left, right, false, method);
    		});
    		return modelBuilder;
    	}
    }
