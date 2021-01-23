    public sealed class ResolvedParserFactory : IParserFactory
    {
        private readonly IContainer _container;
        public ResolvedParserFactory(IContainer container)
        {
            _container = container;
        }
        public IParser<T> CreateParser<T>()
        {
            return _container.Resolve<IParser<T>>();
        }
    }
