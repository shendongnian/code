    <?xml version="1.0" encoding="UTF-8"?>
    <configuration>
    
      <system.web>
        <compilation debug="true" targetFramework="4.0" />
        <httpRuntime maxRequestLength="1048576" executionTimeout="3600" />
      </system.web>
      <appSettings>
        </appSettings>
      <connectionStrings>
        <add name="SQLConnect" connectionString="Your_Connection_String";User id=sa;Password=welcome3#"/>
      </connectionStrings>
      <system.serviceModel>
        <services>
          <service name="WCFRestService.RestServiceSvc" behaviorConfiguration="serviceBehavior">
            <endpoint address="" bindingConfiguration="secureHttpBinding" binding="webHttpBinding" contract="WCFRestService.IRestServiceSvc" behaviorConfiguration="web"></endpoint>
          </service>
        </services>
        <behaviors>
          <endpointBehaviors>
            <behavior name="web">
              <webHttp />
            </behavior>
          </endpointBehaviors>
          <serviceBehaviors>
            <behavior name="serviceBehavior">
              <serviceMetadata httpGetEnabled="true" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
            <behavior name="">
              <serviceMetadata httpGetEnabled="true" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
    
        <bindings>
          <webHttpBinding>
            <binding name="secureHttpBinding"
              maxBufferPoolSize="2147483647"
              maxReceivedMessageSize="2147483647"
              maxBufferSize="2147483647" transferMode="Streamed">       
            </binding>
          </webHttpBinding>
        </bindings>
    
        <serviceHostingEnvironment multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true" />
        <httpProtocol>
          <customHeaders>       
          </customHeaders>
        </httpProtocol>
        <security>
          <requestFiltering>
            <requestLimits maxAllowedContentLength="1073741824" />
          </requestFiltering>
        </security>
        <directoryBrowse enabled="true" />
      </system.webServer>
      <system.web.extensions>
        <scripting>
          <webServices>
            <jsonSerialization maxJsonLength="50000000"/>
          </webServices>
        </scripting>
      </system.web.extensions>
    </configuration>
