    var config = _builder.GetType()
        .GetMethod("Entity")
        .MakeGenericMethod(contentType.Type)
        .Invoke(_builder, null);
    
    var hasKey = config.GetType().GetMethod("HasKey");
    
    var expressionKey = typeof(Expression<>)
        .MakeGenericType(typeof(Func<,>)
        .MakeGenericType(contentType.Type, typeof(Guid)));
    
    var paramEx = Expression.Parameter(contentType.Type, "t");
    var lambdaEx = Expression.Lambda(Expression.Property(paramEx, "Id"), paramEx);
    
    hasKey.MakeGenericMethod(typeof(Guid))
        .Invoke(config, new[] { lambdaEx });
