    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <sectionGroup name="system.serviceModel">
          <section name="domainServices" type="System.ServiceModel.DomainServices.Hosting.DomainServicesSection, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" allowDefinition="MachineToApplication" requirePermission="false" />
        </sectionGroup>
      </configSections>
      <system.web>
    
      <!-- You might need identify tag if you app requires additional permission to run -->
    
      <!-- See you want to see more details when a error happens -->
      <customErrors mode="Off"/>
      <compilation debug="true" targetFramework="4.0" />
    
      <!-- If your application uses authentication and authoriztion then -->
      <!-- Elements required required for authentication: authentication and membership and probably roleManager -->
    
    
    <httpModules>
          <add name="DomainServiceModule" type="System.ServiceModel.DomainServices.Hosting.DomainServiceHttpModule, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </httpModules>
      </system.web>
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false" />
        <modules runAllManagedModulesForAllRequests="true">
          <add name="DomainServiceModule" preCondition="managedHandler"
              type="System.ServiceModel.DomainServices.Hosting.DomainServiceHttpModule, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </modules>
      </system.webServer>
    
      <system.serviceModel>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
    
    </configuration>
