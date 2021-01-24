    var type = typeof(Something);
    // Something s =>
    var parameter = Expression.Parameter(type , "s");
    // Something s => s.SomeProperty
    var property = Expression.Property(parameter, type .GetProperty("SomeProperty"));
    // 12
    var constant = Expression.Constant(12);
    // Something s => s.SomeProperty == 12
    var body = Expression.Equal(property, constant);
    // build the expression
    Expression<Func<Something, bool>> expression = 
        Expression.Lambda<Func<Something, bool>>(body, parameter);
