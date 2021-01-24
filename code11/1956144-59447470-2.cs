    public interface IServiceLookup
    {
        IService<TMessage> Get<TMessage>();
    }
    public class ServiceLookup : IServiceLookup
    {
        public ServiceLookup(IEnumerable<IService> services)
        {
            this._services = services
                .ToDictionary(s => s.GetType()
                    .GetInterfaces()
                    .First(i => i.IsGenericType 
                                && i.GetGenericTypeDefinition() == typeof(IService<>))
                    .GetGenericArguments()[0], 
                              s => s);
        }
        private readonly Dictionary<Type, IService> _services;
        public IService<TMessage> Get<TMessage>()
        {
            // you should check for type missing, etc. 
            return (IService<TMessage>)this._services[typeof(TMessage)];
        }
    }
