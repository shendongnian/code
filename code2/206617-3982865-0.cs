    public ConditionBuilder GreaterThan(object constant)
    {
        condition = Expression.GreaterThan(Expression.Parameter(constant.GetType()), Expression.Constant(constant));
        return this;
    }
