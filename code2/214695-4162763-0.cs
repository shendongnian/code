    private static Dictionary<string, Func<object>> delegates = 
        new Dictionary<string, Func<object>>();
    public static object CreateObjectByName(string name)
    {
        if (delegates.ContainsKey(name))
        {
            return delegates[name]();
        }
        else
        {
            Func<object> creator = CreateDelegateFor(Type.GetType(name));
            // TODO: Don't forget to make this thread-safe :-)
            delegates[name] = creator;
        }
    }
    // .NET Expression tree magic!
    private static Func<object> CreateDelegateFor(Type type)
    {
        var constructor = type.GetConstructors().First();
        var newServiceTypeMethod = Expression.Lambda<Func<object>>(
            Expression.New(constructor, new Expression[0]), 
            new ParameterExpression[0]);
        return newServiceTypeMethod.Compile();
    }
