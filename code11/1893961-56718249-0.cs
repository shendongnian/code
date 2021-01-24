    Expression matchExpression = searchKeyExpression;
    if (matchExpression.Type != typeof(string))
    {
    	matchExpression = Expression.Convert(matchExpression, typeof(object));
    	matchExpression = Expression.Convert(matchExpression, typeof(string));
    }
    var pattern = Expression.Constant($"%{filter.Value}%);
    var callLike = Expression.Call(
    	typeof(DbFunctionsExtensions), "Like", Type.EmptyTypes,
    	Expression.Constant(EF.Functions), matchExpression, pattern);
