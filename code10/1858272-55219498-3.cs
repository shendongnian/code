    /// <summary>
    /// SimpleInjector implementation of the service locator.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        #region member vars
        /// <summary>
        /// The SimpleInjector container.
        /// </summary>
        private readonly Container _container;
        #endregion
        #region constructors and destructors
        public ServiceLocator(Container container)
        {
            _container = container;
        }
        #endregion
        #region explicit interfaces
        /// <inheritdoc />
        public IDisposable BeginAsyncScope()
        {
            return AsyncScopedLifestyle.BeginScope(_container);
        }
        /// <inheritdoc />
        public TService GetInstance<TService>()
            where TService : class
        {
            return _container.GetInstance<TService>();
        }
    }
