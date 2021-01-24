    // We want to build dynamically something like:
    // x => EF.Functions.Like(x.OrderNumber, v1) || EF.Functions.Like(x.OrderNumber, v2)...
    
    var likeMethod = typeof(DbFunctionsExtensions).GetMethod(nameof(DbFunctionsExtensions.Like), BindingFlags.Static | BindingFlags.Public);
    var entityProperty = typeof(Header).GetProperty(nameof(Header.OrderNumber), BindingFlags.Instance | BindingFlags.Public);
    
    // EF.Functions.Like(x.OrderNumber, v1) || EF.Functions.Like(x.OrderNumber, v2)...
    Expression likePredicate = null;
    
    var efFunctionsInstance = Expression.Constant(EF.Functions);
    
    // Will be the predicate paramter (the 'x' in x => EF.Functions.Like(x.OrderNumber, v1)...)
    var lambdaParam = Expression.Parameter(typeof(Header));
    foreach (var number in numbers)
    {
        // EF.Functions.Like(x.OrderNumber, v1)
        //                                 |__|
        var numberValue = Expression.Constant(number);
    
        // EF.Functions.Like(x.OrderNumber, v1)
        //                  |_____________|
        var propertyAccess = Expression.Property(lambdaParam, entityProperty);
    
        // EF.Functions.Like(x.OrderNumber, v1)
        //|____________________________________|
        var likeMethodCall = Expression.Call(likeMethod, efFunctionsInstance, propertyAccess, numberValue);
    
        // Aggregating the current predicate with "OR" (||)
        likePredicate = likePredicate == null
                            ? (Expression)likeMethodCall
                            : Expression.OrElse(likePredicate, likeMethodCall);
    }
    
    // x => EF.Functions.Like(x.OrderNumber, v1) || EF.Functions.Like(x.OrderNumber, v2)...
    var lambdaPredicate = Expression.Lambda<Func<Header, bool>>(likePredicate, lambdaParam);
    
    var filteredQuery = query.Where(lambdaPredicate);
