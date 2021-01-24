    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer().RegisterType(
            typeof(IMyClass),
            typeof(MyClass),
            "",
            new TransientLifetimeManager(),
            new InjectionConstructor("Some nice message"));
        }
    }
    public class MyClass : IMyClass
    {
        public MyClass(string s)
        {
            //...
        }
    }
