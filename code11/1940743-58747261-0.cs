    <configSections>
      <section name="microsoft.web.services3" 
    
        type="Microsoft.Web.Services3.Configuration.WebServicesConfiguration,
             Microsoft.Web.Services3, Version=3.0.0.0, Culture=neutral, 
             PublicKeyToken=31bf3856ad364e35" />
    </configSections>
    
    <system.web>
    
      <compilation debug="true">
        <assemblies>
          <add assembly="Microsoft.Web.Services3, Version=3.0.0.0,
    Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </assemblies>
      </compilation>
    
      <webServices>
        <soapExtensionImporterTypes>
          <add type="Microsoft.Web.Services3.Description.WseExtensionImporter,
                        Microsoft.Web.Services3, Version=3.0.0.0, Culture=neutral, 
                        PublicKeyToken=31bf3856ad364e35" />
        </soapExtensionImporterTypes>
        <soapServerProtocolFactory 
    
          type="Microsoft.Web.Services3.WseProtocolFactory,Microsoft.Web.Services3,
                Version=3.0.0.0,Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
      </webServices>
    </system.web>
    
    <microsoft.web.services3>
      <policy fileName="wse3policyCache.config" />
      <tokenIssuer>
        <statefulSecurityContextToken enabled="false" />
      </tokenIssuer>
    </microsoft.web.services3>
