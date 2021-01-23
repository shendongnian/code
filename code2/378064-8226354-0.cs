    public class AddinsManager : IAddinsManager
    {
        [ImportMany(typeof(IModule))]
        private OrderingCollection<IModule, IOrderMetadata> modules = new OrderingCollection<IModule, IOrderMetadata>(lazyRule => lazyRule.Metadata.Order);
        private CompositionContainer container;
        private bool isInitialized = false;
        /// <summary>
        /// Gets available application modules (add-ins)
        /// </summary>
        public List<IModule> Modules { get; private set; }
        /// <summary>
        /// Initialize manager
        /// </summary>
        public void Initialize()
        {
            Assembly oAssembly = Assembly.GetAssembly(Application.Current.GetType());
            this.container = new CompositionContainer(GetCatalog(oAssembly));
            this.container.ComposeParts(this, Context.Current);
            this.Modules = this.modules
                                .Select(lazy => lazy.Value)
                                .ToList();
            this.isInitialized = true;
        }
        /// <summary>
        /// Initialize modules
        /// </summary>
        public void InitializeModules()
        {
            foreach (IModule oModule in this.Modules)
            {
                oModule.Initialize();
            }
        }
        /// <summary>
        /// Injects dependencies in specified container
        /// </summary>
        /// <param name="host">Container to inject in</param>
        public void Compose(object host)
        {
            if (host == null)
            {
                throw new ArgumentNullException();
            }
            this.EnsureInitialize();
            this.container.ComposeParts(host);
        }
        /// <summary>
        /// Register views of the modules
        /// </summary>
        public void RegisterViews()
        {
            this.EnsureInitialize();
            foreach (IModule oModule in this.Modules)
            {
                foreach (Uri oUri in oModule.GetViewPath().ToArray())
                {
                    ResourceDictionary oDictionary = new ResourceDictionary();
                    oDictionary.Source = oUri;
                    Application.Current.Resources.MergedDictionaries.Add(oDictionary);
                }
            }
        }
        /// <summary>
        /// Get catalog for modules load
        /// </summary>
        /// <param name="assembly">Assembly to search modules</param>
        /// <returns>Catalog for modules load</returns>
        private static AggregateCatalog GetCatalog(Assembly assembly)
        {
            string sDirName = Path.GetDirectoryName(assembly.Location);
            DirectoryCatalog oDirCatalog = new DirectoryCatalog(sDirName, "Company.*");
            AssemblyCatalog oAssemblyCatalog = new AssemblyCatalog(assembly);
            AggregateCatalog oCatalog = new AggregateCatalog(oAssemblyCatalog, oDirCatalog);
            return oCatalog;
        }
        /// <summary>
        /// Ensure if manager was initialized
        /// </summary>
        private void EnsureInitialize()
        {
            if (!this.isInitialized)
            {
                throw new Exception("Add-ins Manager Component not initialized");
            }
        }
    }
