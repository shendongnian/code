    public class ServiceLookup : IServiceLookup
    {
        public ServiceLookup(IComponentContext context)
        {
            this._context = context;
        }
        private readonly IComponentContext _context;
        public IService<TMessage> Get<TMessage>()
        {
            return this._context.Resolve<IService<TMessage>>();
        }
    }
