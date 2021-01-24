    builder.RegisterType<Service>().As<IService>().InstancePerLifetimeScope();
    builder.RegisterType<DbContext>().InstancePerLifetimeScope();
    builder.RegisterType<Operation>().As<IOperation>().InstancePerLifetimeScope();
    public class Operation : IOperation 
    {
        public Operation(Func<Owned<DbContext>> contextFactory, IService service)
        {
            this._contextFactory = contextFactory;
            this._service = service; 
        }
        private readonly Func<Owned<DbContext>> _contextFactory;
        private readonly IService _service;
        public void Do() 
        {
            using Owned<DbContext> context = this._contextFactory(); 
            context.Value // => new instance 
            this._service // shared instance (#1) 
        }
    }
    using (ILifetimeScope scope = container.BeginLifetimeScope())
    {
        scope.Resolve<IService>(); // Instance #1
        IEnumerable<IOperation> operations = scope.Resolve<IEnumerable<IOperation>>())
        operations.AsParallel()
                  .ForAll(operation => operation.Do());
    }
