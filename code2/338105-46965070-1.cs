    public static Func<object, object[], object> ToFastLambdaInvocationWithCache(
       this MethodInfo pMethodInfo
    ) {
       Func<object, object[], object> cached;
       if (sLambdaExpressionsByMethodInfoCache.TryGetValue(pMethodInfo, out cached))
          return cached;
    
       var instanceParameterExpression = Expression.Parameter(typeof(object), "instance");
       var argumentsParameterExpression = Expression.Parameter(typeof(object[]), "args");
    
       var index = 0;
       var argumentExtractionExpressions =
          pMethodInfo
          .GetParameters()
          .Select(parameter =>
             Expression.Convert(
                Expression.ArrayAccess(
                   argumentsParameterExpression,
                   Expression.Constant(index++)
                ),
                parameter.ParameterType
             )
          ).ToList();
       
       var callExpression = pMethodInfo.IsStatic
          ? Expression.Call(pMethodInfo, argumentExtractionExpressions)
          : Expression.Call(
             Expression.Convert(
                instanceParameterExpression, 
                pMethodInfo.DeclaringType
             ),
             pMethodInfo,
             argumentExtractionExpressions
          );
    
       var endLabel = Expression.Label(typeof(object));
       var finalExpression = pMethodInfo.ReturnType == typeof(void)
          ? (Expression)Expression.Block(
               callExpression,
               Expression.Return(endLabel, Expression.Constant(null)), 
               Expression.Label(endLabel, Expression.Constant(null))
            )
          : Expression.Convert(callExpression, typeof(object));
       
       var lambdaExpression = Expression.Lambda<Func<object, object[], object>>(
          finalExpression,
          instanceParameterExpression,
          argumentsParameterExpression
       );
       var compiledLambda = lambdaExpression.Compile();
       sLambdaExpressionsByMethodInfoCache.AddOrReplace(pMethodInfo, compiledLambda);
       return compiledLambda;
    }
