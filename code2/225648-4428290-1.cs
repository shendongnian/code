    /// <summary>
    /// Registers any required routes with the routing system.
    /// </summary>
    [ExportBootstrapperTask("RegisterRoutes")]
    public class RegisterRoutesBootstrapperTask : IBootstrapperTask
    {
        #region Methods
        /// <summary>
        /// Runs the task.
        /// </summary>
        /// <param name="container"></param>
        public void Run(CompositionContainer container)
        {
            Throw.IfArgumentNull(container, "container");
            var registrars = container
                .GetExports<IRouteRegistrar, IOrderedMetadata>()
                .OrderBy(r => r.Metadata.Order)
                .Select(r => r.Value);
            var routes = RouteTable.Routes;
            foreach (var registrar in registrars)
                registrar.RegisterRoutes(routes);
        }
        #endregion
    }
