    /// <summary>
    /// Defines the required contract for implementing a route registrar.
    /// </summary>
    public interface IRouteRegistrar
    {
        #region Methods
        /// <summary>
        /// Registers any required routes.
        /// </summary>
        /// <param name="route">The route collection to register routes with.</param>
        void RegisterRoutes(RouteCollection route);
        #endregion
    }
