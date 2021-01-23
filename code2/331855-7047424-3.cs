    string displayName = GetDisplayName((Dummy x) => x.foo);
    // ...
    public static string GetDisplayName<T, U>(Expression<Func<T, U>> exp)
    {
        var me = exp.Body as MemberExpression;
        if (me == null)
            throw new ArgumentException("Must be a MemberExpression.", "exp");
        var attr = me.Member
                     .GetCustomAttributes(typeof(DisplayAttribute), false)
                     .Cast<DisplayAttribute>()
                     .SingleOrDefault();
        return (attr != null) ? attr.Name : me.Member.Name;
    }
