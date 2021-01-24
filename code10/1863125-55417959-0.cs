    public class MySingletonService
    {
        private readonly IServiceProvider _provider;
        public MySingletonService(IServiceProvider provider)
        {
            _provider = provider;
        }
        ...
    }
