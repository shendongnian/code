    var castedQueryable = personsQueriable.Provider.CreateQuery(
    	Expression.Call(
    		typeof(Queryable), "Cast",
    		new Type[] { persons.First().GetType() },
    		personsQueriable.Expression));
    
    var l = DynamicExpression.ParseLambda(persons.First().GetType(), typeof(bool), "Age > 30");
    var filtered = personsQueriable.Provider.CreateQuery(
    	Expression.Call(
    		typeof(Queryable), "Where",
    		new Type[] { persons.First().GetType() },
    		castedQueryable.Expression, Expression.Quote(l)));
