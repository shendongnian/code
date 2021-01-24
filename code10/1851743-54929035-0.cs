    public static class GuidFunctions
    {
    	public static bool IsGreaterThan(this Guid left, Guid right) => left.CompareTo(right) > 0;
    	public static bool IsGreaterThanOrEqual(this Guid left, Guid right) => left.CompareTo(right) >= 0;
    	public static bool IsLessThan(this Guid left, Guid right) => left.CompareTo(right) < 0;
    	public static bool IsLessThanOrEqual(this Guid left, Guid right) => left.CompareTo(right) <= 0;
    	public static void Register(ModelBuilder modelBuilder)
    	{
    		RegisterFunction(modelBuilder, nameof(IsGreaterThan), ExpressionType.GreaterThan);
    		RegisterFunction(modelBuilder, nameof(IsGreaterThanOrEqual), ExpressionType.GreaterThanOrEqual);
    		RegisterFunction(modelBuilder, nameof(IsLessThan), ExpressionType.LessThan);
    		RegisterFunction(modelBuilder, nameof(IsLessThanOrEqual), ExpressionType.LessThanOrEqual);
    	}
    	static void RegisterFunction(ModelBuilder modelBuilder, string name, ExpressionType type)
    	{
    		var method = typeof(GuidFunctions).GetMethod(name, new[] { typeof(Guid), typeof(Guid) });
    		modelBuilder.HasDbFunction(method).HasTranslation(parameters =>
    		{
    			var left = parameters.ElementAt(0);
    			var right = parameters.ElementAt(1);
    			return Expression.MakeBinary(type, left, right, false, method);
    		});
    	}
    }
