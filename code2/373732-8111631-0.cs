    public void AssociateWithEntity<TProperty>(
        Expression<Func<TEntity, TProperty>> entityExpression,
        TProperty newValueEntity)
        where TProperty : Entity
    {
        if (instanceEntity == null)
            throw new ArgumentNullException();
        var memberExpression = (MemberExpression)entityExpression.Body;
        var property = (PropertyInfo)memberExpression.Member;
        property.SetValue(instanceEntity, newValueEntity, null);
    }
