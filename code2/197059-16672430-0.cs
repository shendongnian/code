    var dict = new Dictionary<string, object>();
    var parameterExpressions = methodCallExpr.Arguments;
                foreach (var param in method.GetParameters())
                {
                    var parameterExpression = parameterExpressions[counter];
                    var paramValueAccessor = Expression.Lambda(parameterExpression);
                    var paramValue = paramValueAccessor.Compile().DynamicInvoke();
    dict[param.Name] = paramValue;
                }
