    public string[] GetPeopleAutoComplete(
        string filter, int maxResults, string searchType, string searchOption)
    {
    	IQueryable<Person> query = _context.People;
    	var property = typeof(Person).GetProperty(searchType);
    	var method = typeof(string).GetMethod(searchOption, new[] { typeof(string) });
    	
    	query = query.Where(WhereExpression(property, method, filter));
    	
    	var resultQuery = query.Select(SelectExpression(property));
    	
    	if (searchType == "Firstname" || searchType == "Lastname")
    		resultQuery = resultQuery.Distinct();
    	
    	return resultQuery.Take(maxResults).ToArray();
    }
    
    Expression<Func<Person, bool>> WhereExpression(
        PropertyInfo property, MethodInfo method, string filter)
    {
    	var param = Expression.Parameter(typeof(Person), "o");
    	var propExpr = Expression.Property(param, property);
    	var methodExpr = Expression.Call(propExpr, method, Expression.Constant(filter));
    	return Expression.Lambda<Func<Person, bool>>(methodExpr, param);
    }
    
    Expression<Func<Person, string>> SelectExpression(PropertyInfo property)
    {
    	var param = Expression.Parameter(typeof(Person), "o");
    	var propExpr = Expression.Property(param, property);
    	return Expression.Lambda<Func<Person, string>>(propExpr, param);
    }
