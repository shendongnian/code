    public static List<T> Get<T>(this SomeObject<T>, Expressions<Func<T>> e, T value)
    {
       //value is SomeValue
       var propertyName = (MemberExpression)e.Member.Name
    }
