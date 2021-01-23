    ParameterExpression param = Expression.Parameter(typeof(TE), "ent");
    MemberExpression prop = Expression.Property(param, 
        typeof(TE).GetProperty("TimeStamp"));
    Expression<Func<TE, DateTime>> lambda = Expression.Lambda<Func<TE, DateTime>>(
        prop, new ParameterExpression[] { param });
    DateTime maxdate = this.EntityCollection.Select(lambda).Max();
