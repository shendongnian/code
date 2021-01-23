    static IDictionary<string, object> GetArgs(Expression<Action> x)
    {
        var args = new Dictionary<string, object>();
        var m = (MethodCallExpression)x.Body;
        var parameters = m.Method.GetParameters();
        for (int i = 0; i < m.Arguments.Count; i++)
        {
            // an easy way of getting at the value, 
            // no matter the complexity of the expression
            args[parameters[i].Name] = Expression
                .Lambda(m.Arguments[i])
                .Compile()
                .DynamicInvoke();
        }
        return args;
    }
