    foreach(var t in types)
    {
        var mapped = typeof(AutoMapping<>).MakeGenericType(t);
    
        var p = Expression.Parameter(mapped, "m");
        var expression = Expression.Lambda(Expression.GetActionType(mapped),
                                           Expression.Call(p, mapped.GetMethod("Do"),
                                           Expression.Constant("Something")), p);
    
        typeof(SomeOtherObject).GetMethod("TheMethod").MakeGenericMethod(t)
                               .Invoke(model, new object[] { expression.Compile() });
    }
