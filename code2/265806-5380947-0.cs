    public class Cache
    {
        public static CacheManager cacheManager = null;
        public static readonly string dependencyFileName = "testCache.xml";            
        public static FileDependency objFileDependency
        {
            get
            {
                return new FileDependency(dependencyFileName);
            }
        }
        public static void Create()
        {
            var builder = new ConfigurationSourceBuilder();
            builder.ConfigureCaching()
                   .ForCacheManagerNamed("TestCache")
                   .UseAsDefaultCache()
                   .StoreInMemory();
            var configSource = new DictionaryConfigurationSource();
            builder.UpdateConfigurationWithReplace(configSource);
            EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
            cacheManager = (CacheManager)EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>("TestCache");
            if (!System.IO.File.Exists(dependencyFileName))
                using (System.IO.File.Create(dependencyFileName)) { }
        }
    }
