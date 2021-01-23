    var dummy = new Dummy();
    string displayName = dummy.GetDisplayName(x => x.foo);
    // ...
    public static string GetDisplayName<T, U>(this T src, Expression<Func<T, U>> exp)
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
