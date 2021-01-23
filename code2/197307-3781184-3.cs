    public static Delegate Create<T>(EventInfo e, Action<T> a)
    {
        var parameters = e.EventHandlerType.GetMethod("Invoke").GetParameters().Select(p => Expression.Parameter(p.ParameterType, "p")).ToArray();
        var exp = Expression.Call(Expression.Constant(a), a.GetType().GetMethod("Invoke"), parameters);
        var l = Expression.Lambda(exp, parameters);
        return Delegate.CreateDelegate(e.EventHandlerType, l.Compile(), "Invoke", false);
    }
