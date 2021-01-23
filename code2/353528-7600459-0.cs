    <unity>
      <namespace name="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity" />
      <assembly name="Microsoft.Practices.EnterpriseLibrary.Common" />
    
      <container>
        <extension type="EnterpriseLibraryCoreExtension" />
        
        <register type="IMyType" mapTo="MyImplementation">
          <constructor>
            <param name="cacheManager" />
          </constructor>
        </register>
      </container>
    </unity>
