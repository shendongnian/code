    var param = Expression.Parameter(typeof(DomainObject));
    var body = Expression.Equal(Expression.Property(param, "SomeProperty"),
                             Expression.Constant(YourEnumType.SomeEnum));
    var predicate = Expression.Lambda<Func<DomainObject, bool>>(body, param);
    var count = db.Table.Where(predicate).Count();
