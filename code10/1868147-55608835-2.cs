      // assemblies - assemblies with your handlers 
    var notificationHandlerTypes = 
        Container.GetTypesToRegister(typeof(IHandleEvent<>), assemblies, new 
            TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
    Container.Collection.Register(typeof(IHandleEvent<>), notificationHandlerTypes);
