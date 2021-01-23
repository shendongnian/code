    var propertyInfo = typeof(T).GetProperty(sortExpressionStr);
    Type orderType = propertyInfo.PropertyType;
    // first find the OrderBy method with no types specified
    MethodInfo method = typeof(Queryable).GetMethods()
      .Where(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
      .Single();
    // then make the right version by supplying the right types
    MethodInfo concreteMethod = method.MakeGenericMethod(typeof(T), orderType);
    var param = Expression.Parameter(typeof(T), "x");
    // the key selector for the OrderBy method
    Expression orderBy =
        Expression.Lambda(
            Expression.Property(orderParam, propertyInfo),
            orderParam);
    // how to use:
    var sequence = new T[0].AsQueryable(); // sample IQueryable
    // because no types are known in advance, we need to call Invoke 
    // through relection here
    IQueryable result = (IQueryable) concreteMethod.Invoke(
                                       null, // = static
                                       new object[] { sequence, orderBy });
