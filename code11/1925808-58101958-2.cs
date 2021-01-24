    public void UseNames(string className, string memberName)
    {
        // Your code to use the class & membername go here
    }
    public void UseNames<T>(Expression<Func<T, object>> expression)
    {
        MemberExpression member = expression.Body as MemberExpression;
        if (member == null)
        {
            // The property access might be getting converted to object to match the func
            // If so, get the operand and see if that's a member expression
            member = (expression.Body as UnaryExpression)?.Operand as MemberExpression;
        }
        if (member == null)
        {
            throw new ArgumentException("Action must be a member expression.");
        }
        // Pass the names on to the string-based UseNames method
        UseNames(typeof(T).Name, member.Member.Name);
    }
    public void UseNames<T>(Expression<Func<T, string>> expression)
    {
        ConstantExpression constant = expression.Body as ConstantExpression;
        if (constant == null)
        {
            throw new ArgumentException("Expression must be a constant expression.");
        }
        UseNames(typeof(T).Name, constant.Value.ToString());
    }
