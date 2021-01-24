    public static Expression<Func<T, bool>> CreatExpression<T>(T toInsert)
    {
        var type = typeof(T);
        var membersToTrack = type.GetMembers(
            BindingFlags.GetField
            | BindingFlags.GetProperty
            | BindingFlags.Instance
            | BindingFlags.Public)
            .Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(MustBeUniqueAttribute)))
            .ToArray();
        var parameter = Expression.Parameter(type, "x");
        if (membersToTrack.Length == 0)
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(false), parameter);
        Expression body = null;
        foreach (var member in membersToTrack)
        {
            object actualValue = null;
            if (member is PropertyInfo info)
                actualValue = info.GetValue(toInsert);
            else
                actualValue = ((FieldInfo) member).GetValue(toInsert);
            var leftExpression = Expression.PropertyOrField(parameter, member.Name);
            var rightExpression= Expression.Constant(actualValue);
            var equalExpression = Expression.Equal(leftExpression, rightExpression);
            body = body == null ? equalExpression : Expression.AndAlso(body, equalExpression);
        }
        var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
        return lambda;
    }
    
