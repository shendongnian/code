    Bind<ISomething>().To<Default>().Binding.IsImplicit = true;
    Bind<ISomething>().To<Other>().Named("SomeName")
    
    public static T GetNamedOrDefault<T>(this IKernel kernel, string name)
    {
        return kernel.Get<T>(m => m.Name == null || m.Name == name);
    }
