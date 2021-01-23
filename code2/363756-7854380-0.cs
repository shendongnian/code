    string propertyName
    string keyword
    
    ParameterExpression parameter = Expression.Parameter(typeof(YourType), "x");
    Expression property = Expression.Property(parameter, propertyName);
    Expression target = Expression.Constant(keyword);
    Expression containsMethod = Expression.Call(property, "Contains", null, target);
    Expression<Func<YourType, bool>> lambda =
       Expression.Lambda<Func<YourType, bool>>(containsMethod, parameter);
    
    var companies = repository.AsQueryable().Where(lambda);
