    static void AddApplicationPart(IMvcBuilder mvcBuilder, Assembly assembly)
    {
        var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
        foreach (var part in partFactory.GetApplicationParts(assembly))
        {
            mvcBuilder.PartManager.ApplicationParts.Add(part);
        }
        var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(assembly, throwOnError: false);
        foreach (var relatedAssembly in relatedAssemblies)
        {
           partFactory = ApplicationPartFactory.GetApplicationPartFactory(relatedAssembly);
           foreach (var part in partFactory.GetApplicationParts(relatedAssembly))
           {
               mvcBuilder.PartManager.ApplicationParts.Add(part);
           }
        }
    }
