    // Build up the property expression to pass into the OrderBy method
	var parameterExp = Expression.Parameter(typeof(T), "x");
	var propertyExp = Expression.Property(parameterExp, keyField);
	var orderByExp = Expression.Lambda(propertyExp, parameterExp);
    // Note here you can output "orderByExp.ToString()" which will give you this:
    //  x => x.NameOfProperty
    // Now call the OrderBy via reflection, you can decide here if you want 
    // "OrderBy" or "OrderByDescending"
	var orderByMethodGeneric = typeof(Queryable)
		.GetMethods()
		.Single(mi => mi.Name == "OrderBy" && mi.GetParameters().Length == 2);
	var orderByMethod = orderByMethodGeneric.MakeGenericMethod(typeof(T), propertyExp.Type);
    // Get the result
	var sortedQueryable = (IQueryable<T>)orderByMethod
        .Invoke(null, new object[] { queryable, orderByExp });
