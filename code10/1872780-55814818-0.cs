    if (source.Type != type && source is MethodCallExpression call && call.Method.IsStatic
    	&& call.Method.DeclaringType == typeof(Enumerable) && call.Method.Name == nameof(Enumerable.Select))
    {
    	var sourceEnumerable = call.Arguments[0];
    	var sourceSelector = (LambdaExpression)call.Arguments[1];
    	var sourceElementType = sourceSelector.Parameters[0].Type;
    	var targetElementType = type.GetGenericArguments()[0];
    	var targetSelector = Expression.Lambda(
    		Transform(sourceSelector.Body, targetElementType),
    		sourceSelector.Parameters);
    	var targetMethod = call.Method.GetGenericMethodDefinition()
    		.MakeGenericMethod(sourceElementType, targetElementType);
    	var result = Expression.Call(targetMethod, sourceEnumerable, targetSelector);
    	if (type.IsAssignableFrom(result.Type)) return result;
    	return Expression.Call(
    		typeof(Enumerable), nameof(Enumerable.ToList), new[] { targetElementType },
    		result);
    }
 
