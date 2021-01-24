    public static void NewIfNull<TObj, TProperty>(this TObj obj, Expression<Func<TObj, TProperty>> selector)
    {
        object subject = obj;
        foreach (var member in GetMembers().Reverse())
        {
            if (!(member.Member is PropertyInfo propertyInfo))
            {
                throw new ArgumentException("Member was not a property", nameof(selector));
            }
            var property = propertyInfo.GetValue(subject);
            if (property == null)
            {
                property = Activator.CreateInstance(propertyInfo.PropertyType);
                propertyInfo.SetValue(subject, property);
            }
            subject = property;
        }
        IEnumerable<MemberExpression> GetMembers()
        {
            for (var member = GetMember(selector.Body); member != null; member = GetMember(member.Expression))
            {
                yield return member;
            }
        }
        MemberExpression GetMember(Expression expr)
        {
            if (expr is ParameterExpression)
            {
                return null;
            }
            if (expr is MemberExpression member)
            {
                return member;
            }
            throw new ArgumentException("Expected a lambda in the form x => x.A.B.C", nameof(selector));
        }
    }
