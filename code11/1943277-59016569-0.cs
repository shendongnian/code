c#
IocManager.IocContainer.Register(Component.For(typeof(QueryService<,>)));
IocManager.IocContainer.Register(Component.For(typeof(QueryServiceString<>)));
IocManager.IocContainer.Register(Component.For(typeof(IQueryService<,>))
    .UsingFactoryMethod((kernel, creationContext) =>
    {
        Type type = null;
        var tEntity = creationContext.GenericArguments[0];
        var tPrimaryKey = creationContext.GenericArguments[1];
        if (tPrimaryKey == typeof(string))
        {
            type = typeof(QueryServiceString<>).MakeGenericType(tEntity);
        }
        else
        {
            type = typeof(QueryService<,>).MakeGenericType(tEntity, tPrimaryKey);
        }
        return kernel.Resolve(type);
    }));
