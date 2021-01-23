    foreach(var t in types)
    {
        var type = typeof(AutoMapping<>).MakeGenericType(t);
        var mapped = typeof(Action<>).MakeGenericType(type);
    
        var p = Expression.Parameter(parentType, "m");
        var expression = Expression.Lambda(Expression.GetActionType(mapped),
                                           Expression.Call(p, mapped.GetMethod("Do"),
                                           Expression.Constant("Something")), p);
    
        typeof(SomeOtherObject).GetMethod("TheMethod").MakeGenericMethod(t)
                               .Invoke(model, new object[] { expression.Compile() });
    }
