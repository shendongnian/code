public static Action<T, DateTime> AssignValueToProperty<T>(string propertyName)
{
    var arg = Expression.Parameter(typeof(T), "arg");
    var startTime = Expression.Parameter(typeof(DateTime), startTime);
    var property = Expression.Property(arg, propertyName);
    var body = Expression.Assign(property, property );
    var exp = Expression.Lambda<Action<T, DateTime>>(body, new ParameterExpression[] { arg, startTime });
    return exp.Compile();
}
