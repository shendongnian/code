    // grab the property expression out of your ordering statement
    var expressionProperty = criteria.OrderBy.Body is UnaryExpression ? (MemberExpression)((UnaryExpression)criteria.OrderBy.Body).Operand : (MemberExpression)criteria.OrderBy.Body;
    // recreate the lambda as Expression<Func<T,U>> where T is the queryable element type and U 
    // is the actual type of the property, not an object
    var orderBy = Expression.Lambda(expressionProperty, criteria.OrderBy.Parameters.Single());
    
    // apply new lambda instead
    var sortedQuery = query.OrderBy(orderBy);
