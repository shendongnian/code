    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="microsoft.web.services2" type="Microsoft.Web.Services2.Configuration.WebServicesConfiguration, Microsoft.Web.Services2, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
      </configSections>
      
      <system.web>
        <webServices>
          <soapExtensionTypes>
            <add type="Microsoft.Web.Services2.WebServicesExtension, Microsoft.Web.Services2, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" priority="1" group="0" />
          </soapExtensionTypes>
        </webServices>
      </system.web>
      <microsoft.web.services2>
        <messaging>
          <maxRequestLength>1024000</maxRequestLength>
        </messaging>
        <diagnostics />
      </microsoft.web.services2>
    </configuration>
