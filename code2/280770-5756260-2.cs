    <?xml version="1.0" encoding="utf-8"?>
    <system.serviceModel>
      <service behaviorConfiguration="DefaultWcfServiceBehavior" name="Your.Namespace.SystemService ">
        <endpoint contract="Your.Namespace.Contract.ISystemService "
          binding="webHttpBinding" behaviorConfiguration="JsonBehavior">
        </endpoint>
      </service>
      
      <bindings>
        <basicHttpBinding>
          <binding name="BasicHttpEndpointBinding" receiveTimeout="00:20:00" maxReceivedMessageSize="2000000000">
            <security mode="TransportCredentialOnly">
              <transport clientCredentialType="Windows" />
            </security>
          </binding>
        </basicHttpBinding>
      </bindings>
      
      <behaviors>
        <endpointBehaviors>
          <behavior name="JsonBehavior">
            <enableWebScript/>
          </behavior>
        </endpointBehaviors>
        <serviceBehaviors>
          <behavior name="DefaultWcfServiceBehavior">
            <serviceMetadata httpGetEnabled="true" />
            <serviceDebug includeExceptionDetailInFaults="true" />
          </behavior>
        </serviceBehaviors>
      </behaviors>
      
    </system.serviceModel>
