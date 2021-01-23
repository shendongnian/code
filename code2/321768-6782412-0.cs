    public static class DependencyResolverExtensions
    {
            public static object GetService(this IDependencyResolver resolver, Type serviceType, string instanceName)
            {
                var smResolver = resolver as SmDependencyResolver;
                if (smResolver == null) throw new NotSupportedException();
                return smResolver.Container.GetInstance(serviceType, instanceName);
            }
    }
