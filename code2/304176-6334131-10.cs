    var registerTypeMethodInfo = 
         typeof(IUnityContainer).GetMethods()
                                .Where(m => m.Name == "RegisterType")
                                .Where(m => m.GetParameters()
                                     .Select(p => p.ParameterType)
                                     .SequenceEqual(new[] {
                                          typeof(string), 
                                          typeof(LifetimeManager),
                                          typeof(InjectionMember[])
                                     })
                                )
                                .Where(m => m.GetGenericArguments().Count() == 2)
                                .SingleOrDefault();
    Assert.NotNull(registerTypeMethodInfo);
    var methodInfo = 
        registerTypeMethodInfo.MakeGenericMethod(new[] {
            typeof(IMyDataProvider), 
            typeof(MockData.MockProvider)
        });
