    string displayName = GetDisplayName((Dummy x) => x.foo);
    // ...
    public static string GetDisplayName<T, U>(Expression<Func<T, U>> expr)
    {
        var me = expr.Body as MemberExpression;
        if (me == null)
            throw new ArgumentException("Must be a MemberExpression.", "expr");
        var attr = (DisplayAttribute)me.Member
                                       .GetCustomAttributes(typeof(DisplayAttribute))
                                       .SingleOrDefault();
        return (attr != null) ? attr.Name : me.Member.Name;
    }
