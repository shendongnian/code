    public static Action<TContaining, TProperty>
        CreateSetter<TContaining, TProperty>
        (Expression<Func<TContaining, TProperty>> getter)
    {
        if (getter == null)
            throw new ArgumentNullException("getter");
        var memberEx = getter.Body as MemberExpression;
        if (memberEx == null)
            throw new ArgumentException("Body is not a member-expression.");
        var property = memberEx.Member as PropertyInfo;
        if (property == null)
            throw new ArgumentException("Member is not a property.");
        if(!property.CanWrite)
            throw new ArgumentException("Property is not writable.");
        return (Action<TContaining, TProperty>)
               Delegate.CreateDelegate(typeof(Action<TContaining, TProperty>),
                                       property.GetSetMethod());
    }
