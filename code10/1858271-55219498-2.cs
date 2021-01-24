    /// <summary>
    /// A simple service locator to hide the real IOC Container.
    /// Lowers the anti-pattern of service locators a bit.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Begins an new async scope.
        /// The scope should be disposed explicitly.
        /// </summary>
        /// <returns></returns>
        IDisposable BeginAsyncScope();
        /// <summary>
        /// Gets an instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of the requested service.</typeparam>
        /// <returns>The requested service instance.</returns>
        TService GetInstance<TService>() where TService : class;
    }
