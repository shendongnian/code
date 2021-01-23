    var dataContextParameter = Expression.Parameter(typeof(ModelDataContext), "dataContext");
    var valueParameter = Expression.Parameter(typeof(object), "value");
    var getTableCall = Expression.Call(
        dataContextParameter,
        "GetTable",
        new[] { entityType });
    var entity = Expression.Parameter(entityType, "entity");
    var idCheck = Expression.Equal(
        Expression.Property(entity, "Id"),
        valueParameter);
    var idCheckLambda = Expression.Lambda(idCheck, entity);
    var singleOrDefaultCall = Expression.Call(
        typeof(Queryable),
        "SingleOrDefault",
        new[] { entityType },
        getTableCall,
        Expression.Quote(idCheckLambda));
    var singleOrDefaultLambda =
        Expression.Lambda<Func<ModelDataContext, object, object>>(
            Expression.Convert(singleOrDefaultCall, typeof(object)),
            dataContextParameter,
            valueParameter);
    var singleOrDefaultFunction = singleOrDefaultLambda.Compile();
    // Usage
    using(var dataContext = new DataModel.ModelDataContext())
    {
        return singleOrDefaultFunction(dataContext, reader.Value);    
    }
