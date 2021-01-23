    var param = Expression.Parameter(typeof(MyObject), "t");
    var body = Expression.Or(
                Expression.Equal(Expression.PropertyOrField(param, "Email"), Expression.Constant("email@domain.com")),
                Expression.Call(Expression.PropertyOrField(param, "Email"), "Contains", null, Expression.Constant("mydomain"))
            );
    body = Expression.AndAlso(body, Expression.Equal(Expression.PropertyOrField(param, "Field1"), Expression.Constant("valuewewant")));
    body = Expression.AndAlso(body, Expression.NotEqual(Expression.PropertyOrField(param, "Field2"), Expression.Constant("valuewedontwant")));
    var lambda = Expression.Lambda<Func<MyObject, bool>>(body, param);
    var data = source.Where(lambda);
