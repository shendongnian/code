    static void Main()
    {
        var b = 123;
        Expression<Action> x = () => SomeMethod("a", b, "a" + b);
        var args = GetArgs(x);
        foreach (var item in args)
        {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }
    }
    static IDictionary<string, object> GetArgs(Expression<Action> x)
    {
        var args = new Dictionary<string, object>();
        var m = (MethodCallExpression)x.Body;
        var parameters = m.Method.GetParameters();
        for (int i = 0; i < m.Arguments.Count; i++)
        {
            // an easy way of getting at the value, 
            // no matter the complexity of the expression
            args[parameters[i].Name] = Expression.Lambda(m.Arguments[i]).Compile().DynamicInvoke();
        }
        return args;
    }
    static void SomeMethod(string arg1, int arg2, object arg3)
    {
    }
