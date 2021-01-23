    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        /// <returns>The generated unity container</returns>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // Example
            container.RegisterType<IFileSystem, FileSystem>();
        }
    }
    var unity = new UnityConfig();
    IUnityContainer unityContainer = UnityConfig.GetConfiguredContainer();
