	public static void Test()
	{
		var myItem = new Item() { Cost = 67.5 };
		var items = new List<Item> { myItem };
		var result = items.Where(m => 
		m.Cost.ToString().ToLower().
		Contains("67,5")).ToList();
		var whereClause = ContainsPredicate<Item>("Cost", "67,5");
		// var test1 = whereClause(myItem);
		var result2 = items.Where(whereClause).ToList(); // returns 1 result in my case
	}
	public static Func<T, bool> ContainsPredicate<T>(string memberName, string searchValue)
	{
		var parameter = Expression.Parameter(typeof(T), "m");
		var member = Expression.PropertyOrField(parameter, memberName);
		// Mistake was here:
		var doubleToStr = member.Type.GetMethod("ToString", Type.EmptyTypes);
		MethodCallExpression memberToString = Expression.Call(member, doubleToStr);
		MethodCallExpression memberToLower = 
			Expression.Call(memberToString, "ToLower", null);
		var body = Expression.Call(memberToLower, "Contains", Type.EmptyTypes
			, Expression.Constant(searchValue));
		var lamb = Expression.Lambda<Func<T, bool>>(body, parameter);
		// we need to compile
		return lamb.Compile();
	}
