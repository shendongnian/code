    private static void SetupEcommerceLogic(IServiceCollection services, bool enabled)
    {
        if (enabled) 
        {
            services.AddTransient<IOrderBusinessLogic, OrderBusinessLogic>();
            return;
        }
        //just pick one interface in the correct assembly.
        var types = Assembly.GetAssembly(typeof(IOrderBusinessLogic)).GetExportedTypes();
        AddFakeImplementations(services, types);
    }
    using ImpromptuInterface;
    private static void AddFakeImplementations(IServiceCollection services, Type[] types)
    {
        //filtering on public interfaces and my folder structure / naming convention
        types = types.Where(x =>
            x.IsInterface && x.IsPublic &&
            (x.Namespace.Contains("BusinessLogic") || x.Namespace.Contains("Repositories"))).ToArray();
        foreach (Type type in types)
        {
            dynamic expendo = new ExpandoObject();
            var fakeImplementation = Impromptu.DynamicActLike(expendo, type);
            services.AddTransient(type, x => fakeImplementation);
            
        }
    }
