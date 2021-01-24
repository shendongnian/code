    public static T BuildDelegate<T>(MethodInfo method) {
        var dgtMi = typeof(T).GetMethod("Invoke");
        var dgtParams = dgtMi.GetParameters();
        var preDeterminedParams = new ParameterExpression[2] {
             Expression.Parameter(dgtParams[0].ParameterType, "arg0"),
             Expression.Parameter(typeof(object[]), "arg1")
        };
        ParameterInfo[] methodParams = method.GetParameters();
        var paramThis = Expression.Convert(preDeterminedParams[0], method.DeclaringType);
        // arg1 =>
        var arg1 = preDeterminedParams[1];
        var paramsToPass = CreateParam(arg1, methodParams);
        var expr = Expression.Lambda<T>(
            Expression.Call(paramThis, method, paramsToPass),
            preDeterminedParams);
        return expr.Compile();
    }
    private static Expression[] CreateParam(ParameterExpression arg1, ParameterInfo[] parameters) {
        var expressions = new Expression[parameters.Length];
        for (int i = 0; i < parameters.Length; i++) {            
            //arg1 => Convert(arg1[i], SomeType)
            expressions[i] = Expression.Convert(
                             Expression.ArrayIndex(arg1, Expression.Constant(i)),
                             parameters[i].ParameterType);
        }
        return expressions;
    }
