    public class MyServiceLocator
    {
        private static MyServiceLocator _instance;
        private IContainer _container;
        
        private ILifetimeScope _myViewLifetimeScope;
    
        private MyServiceLocator()
        {
            RegisterServices();
        }
    
        private void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MyAutofacModule>();
            _container = builder.Build();
        }
    
        public static MyServiceLocator Instance => _instance ?? (_instance = new MyServiceLocator());
    
        public IMyView MyView
        {
            get
            {
                _myViewLifetimeScope = _container.BeginLifetimeScope();
                return _myViewLifetimeScope.Resolve<IMyView>();
            }
        }
    
        public void EndMyViewLifetimeScope()
        {
            _myViewLifetimeScope?.Dispose();
        }
    }
