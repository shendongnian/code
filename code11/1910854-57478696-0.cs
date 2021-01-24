    public class Bootstrapper : BootstrapperBase
    {
        private readonly BindableCollection<MyObject> _myObjects = new BindableCollection<MyObject>();
        private SimpleContainer container;
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Handler<ShellViewModel>(_ => new ShellViewModel(_myObjects));
            container.Handler<SomeOtherViewModel>(_ => new SomeOtherViewModel(_myObjects));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor(typeof(ShellViewModel));
        }
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
