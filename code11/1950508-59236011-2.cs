    public class SthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(ISthScopedService))))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope(); // Add similar for the other two lifetimes
            base.Load(builder);
        }
    }
