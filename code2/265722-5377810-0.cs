    	// p => p.Person.Name == "Mike"
	ParameterExpression par = Expression.Parameter(typeof(PersonContainer), "p");
	BinaryExpression beEq = Expression.Equal(
		Expression.Property(
			Expression.Property(par, "Person"), 
			"Name"),
		Expression.Constant("Mike"));
	Expression<Func<PersonContainer, bool>> expr = Expression.Lambda<Func<PersonContainer, bool>>(beEq, par);
