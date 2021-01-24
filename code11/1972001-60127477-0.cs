    public interface IClientFactory
    {
        IPublicationApiClient<T> Create<T>(T publication) where T : Publication;
    }
    public class ClientFactory : IClientFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IPublicationApiClient<T> Create<T>(T publication) where T : Publication
        {
            return _serviceProvider.GetService<IPublicationApiClient<T>>()
                ?? throw new NotSupportedException();
        }
    }
