      <add expirationPollFrequencyInSeconds="240" maximumElementsInCacheBeforeScavenging="1000"
        numberToRemoveWhenScavenging="10" backingStoreName="CacheViaADatabase"
        type="Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager, Microsoft.Practices.EnterpriseLibrary.Caching, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        name="IPrincipalCache" />
    </cacheManagers>
    <backingStores>
      <add databaseInstanceName="CachingConnectionString" partitionName="CS" encryptionProviderName="" type="Microsoft.Practices.EnterpriseLibrary.Caching.Database.DataBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching.Database, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" 
           name="CacheViaADatabase"/>
    </backingStores>
