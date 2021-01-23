    <services>
      <service name="Vendor.Services.Provider.Host.Implementation.ProviderService">
        <endpoint
          binding="ws2007FederationHttpBinding" 
          bindingConfiguration="Vendor.Services.Provider.Contracts.ServiceContracts.IProviderService_ws2007FederationHttpBinding" 
          contract="Vendor.Services.Provider.Contracts.ServiceContracts.IProviderService"/>
      </service>
    </services>
