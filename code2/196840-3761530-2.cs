    var memberExpression = projection.Body as MemberExpression;
    if (memberExpression == null)
    {
        throw new ArgumentException("Lambda was not a member access");
    }
    var propertyInfo = memberExpression.Member as PropertyInfo;
    if (propertyInfo == null)
    {
        throw new ArgumentException("Lambda was not a property access");
    }
    if (projection.Parameters.Count != 1 ||
        projection.Parameters[0] != memberExpression.Expression)
    {
        throw new ArgumentException("Property was not invoked on parameter");
    }
    if (!propertyInfo.CanWrite)
    {
        throw new ArgumentException("Property is read-only");
    }
    // Now we've got a PropertyInfo which we should be able to write to - 
    // although the setter may be private. (Add more tests for that...)
    // Stash propertyInfo appropriately, and use PropertyInfo.SetValue when you 
    // need to.
