    public Expression<Func<Customer, bool>> BuildExpression()
    {
        Expression<Func<Customer, bool>> predicate = c => c.Id == CustomerId;
        if (State != null)
        {
            var parameter = predicate.Parameters.First();
            var newBody = Expression.AndAlso(
                predicate.Body,
                Expression.Equal(
                    Expression.PropertyOrField(parameter, nameof(State)),
                    Expression.Constant(State)
                ));
            predicate = Expression.Lambda<Func<Customer, bool>>(newBody, parameter);
        }
        return predicate;
    }
