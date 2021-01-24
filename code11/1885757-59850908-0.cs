c#
List<string> properties = ... ;
var parameter = Expression.Parameter(typeof(T), "e");
var selectExpression = Expression.Lambda<Func<T, object[]>>(
    Expression.NewArrayInit(
        typeof(object),
        properties.Select(p =>
        {
            var ret = Expression.Property(parameter, p);
            if (ret.Type != typeof(object))
                ret = Expression.Convert(ret, typeof(object));
            return ret;
        })
    ),
    parameter);
