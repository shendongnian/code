    public static string DoSomething(Expression<Func<int>> expression) 
    {
        MemberExpression memberExpression = (MemberExpression)expression.Body;
        Type type = memberExpression.Member.ReflectedType; // MyType
        bool check = typeof(MyType).IsAssignableFrom(type); // So you could check for base class
        // If you want to check for exactly one class, do 
        // bool type == typeof(MyType);
        if (!check) 
        {
            throw new Exception();
        }
        return null;
    }
