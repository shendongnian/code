foreach (var prop in typeof(T).GetProperties()) {
    var parameter = Expression.Parameter(typeof(T), "x");
    var property = Expression.Property(parameter, prop);
    var cast = Expression.Convert(property, typeof(object));
    var lambda = Expression.Lambda<Func<T, object>>(cast, parameter);
    if (prop.Name == "ID")
        fluentMappingBuilder.Entity<T>().Property(lambda).IsIdentity().IsPrimaryKey();
    else
        fluentMappingBuilder.Entity<T>().Property(lambda);
}
That is, we have to construct the entire `LambdaExpression` ourselves.
