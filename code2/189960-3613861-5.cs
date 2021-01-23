    public bool MakePayment(TPayment payment)
    {
        Expression<Func<int, bool>> expr = parcelId => parcelId == 2;
        var parameter = Expression.Parameter(typeof(TParcel));
        // This is the expression “p.ParcelId”, where “p” is the parameter
        var propertyExpression = Expression.Property(parameter, "ParcelId");
        var lambda = Expression.Lambda(Expression.Invoke(expr, propertyExpression),
                                       parameter);
        ParcelRepository.Get((Expression<Func<TParcel, bool>>) lambda);
    }
