    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<NeedsBar>().DependsOn(Dependency.OnComponent<IBar, Foo>()));
        }
    }
