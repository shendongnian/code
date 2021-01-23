    protected override void Load(ContainerBuilder builder)
    {
        foreach (var componentType in allTypesInAllAvailableAssemblies.OfType<Type>().Distinct()) // Set elsewhere
        {
            var handlerInterfaces = componentType.GetInterfaces().Where(i => i.IsClosedTypeOf(typeof(IMessageHandler<>)));
            if (handlerInterfaces.Any())
                builder.RegisterType(componentType).As(handlerInterfaces);
        }
    }
