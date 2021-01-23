    var prop1 = // first property
    var prop2 = // second property
 
    // Variable has type of the declarating type of the 1st property
    var instance = Expression.Parameter(prop1.DeclaringType, "i"); 
    // Get first property on the 'instance'
    var expr1 = Expression.Property(instance, prop1); 
    // Get second property on the previous expression
    var expr2 = Expression.Property(expr, prop2); 
    // The rest of the code stays the same (only use 'expr2')
    var propertyValue = Expression.Constant(propertyInfo.GetValue(_myEntity, null)); 
    var equalityCheck = Expression.Equal(expr2, propertyValue); 
    return Expression.Lambda<Func<MyEntity, bool>>
      (equalityCheck, instance).Compile(); 
