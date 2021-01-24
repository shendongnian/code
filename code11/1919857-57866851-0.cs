    var configSource = new DictionaryConfigurationSource();
    var cacheSettings = new CacheManagerSettings();
    
    configSource.Add(CacheManagerSettings.SectionName, cacheSettings);
    var storageConfig = new CacheStorageData("NullBackingStore", typeof(NullBackingStore));
    cacheSettings.BackingStores.Add(storageConfig);
    
    var cacheManagerData = new CacheManagerData(
        "Cache Manager",
        60,
        1000,
        10,
        storageConfig.Name);
    cacheSettings.CacheManagers.Add(cacheManagerData);
    cacheSettings.DefaultCacheManager = "Cache Manager";
    cacheSettings.DefaultCacheManager = cacheManagerData.Name;
    
    EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
