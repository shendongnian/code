    using(var dataContext = new DataModel.ModelDataContext())
    {
        var getTableCall = Expression.Call(
            Expression.Constant(dataContext),
            "GetTable",
            new[] { entityType });
        var entity = Expression.Parameter(entityType, "entity");
        var idCheck = Expression.Equal(
            Expression.Property(entity, "Id"),
            Expression.Constant(reader.Value));
        var idCheckLambda = Expression.Lambda(idCheck, entity);
        var singleOrDefaultCall = Expression.Call(
            typeof(Queryable),
            "SingleOrDefault",
            new[] { entityType },
            getTableCall,
            Expression.Quote(idCheckLambda));
        var singleOrDefaultLambda = Expression.Lambda<Func<object>>(
            Expression.Convert(singleOrDefaultCall, typeof(object)));
        var singleOrDefaultFunction = singleOrDefaultLambda.Compile();
        return singleOrDefaultFunction();    
    }
