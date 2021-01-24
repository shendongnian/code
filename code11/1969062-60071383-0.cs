    public Expression<Func<T, T>> Select()
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
        NewExpression objToInitialise = Expression.New(typeof(T));
        IEnumerable<MemberAssignment> propertiesToInitialise = _properties.Select(property =>
            {
                MemberExpression originalValue = Expression.Property(parameter, property);
                return Expression.Bind(property, originalValue);
            }
        );
        MemberInitExpression initializedMember = Expression.MemberInit(objToInitialise, propertiesToInitialise);
        return Expression.Lambda<Func<T, T>>(initializedMember, parameter);
    }
