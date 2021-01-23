    public class ValueResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                    .BasedOn<IValueResolver>()
                                    .LifestyleTransient());
        }
    }
