    public class WorkerService
    {
        private readonly IContainer _container = null;
    
        public WorkerService(IContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
        }
    
        private IDataContextFactory _contextFactory = null;
        public IDataContextFactory ContextFactory
        {
            get { return _contextFactory ?? (_contextFactory = _container.Resolve<IDataContextFactory>()); }
            set { _contextFactory = value; }
        }
    
        public void Execute()
        {
             using(var context = ContextFactory.Create()) // returns a DataContext.
             {
                 // do stuff.
             }
        }
    
    }
