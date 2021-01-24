    var user = new User();
	
	var paramExpr = Expression.Parameter(typeof(User), "user");
	var propertyExpression = Expression.Property(paramExpr, "Name");
	Expression.Lambda<Action<User>>(
	    Expression.Assign(
	        propertyExpression,
	        Expression.Constant("Joe Foo")
	    ),
	    new List<ParameterExpression>() { paramExpr }
	).Compile()(user);
    Console.WriteLine(user.Name); //Joe Foo
