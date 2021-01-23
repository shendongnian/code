    public class ComponentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var allTypesFromBinDir = AllTypes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory));
            container.Register(allTypesFromBinDir
                .BasedOn<IComponentService>()
                .WithService.FromInterface());
        }
    }
