    using System.Linq.Expressions;
    public static TDelegate CreateAccessor<TDelegate>(string memberName) where TDelegate : Delegate
    {
        var invokeMethod = typeof(TDelegate).GetMethod("Invoke");
        if (invokeMethod == null)
            throw new InvalidOperationException($"{typeof(TDelegate)} signature could not be determined.");
        
        var delegateParameters = invokeMethod.GetParameters();    
        if (delegateParameters.Length != 1)
            throw new InvalidOperationException("Delegate must have a single parameter.");
            
        var paramType = delegateParameters[0].ParameterType;
            
        var objParam = Expression.Parameter(paramType, "obj");
        var memberExpr = Expression.PropertyOrField(objParam, memberName);
        Expression returnExpr = memberExpr;
        if (invokeMethod.ReturnType != memberExpr.Type)
            returnExpr = Expression.ConvertChecked(memberExpr, invokeMethod.ReturnType);
            
        var lambda = Expression.Lambda<TDelegate>(returnExpr, $"Access{paramType.Name}_{memberName}", new [] { objParam });
        return lambda.Compile();
    }
