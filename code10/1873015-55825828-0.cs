    <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior>
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
              <serviceCredentials>
                <userNameAuthentication customUserNamePasswordValidatorType="WcfService1.CustUserNamePasswordVal,WcfService1" userNamePasswordValidationMode="Custom"/>
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <bindings>
          <wsHttpBinding>
            <binding>
              <security mode="TransportWithMessageCredential">
                <message clientCredentialType="UserName"/>
              </security>
            </binding>
          </wsHttpBinding>
        </bindings>
        <protocolMapping>
          <add binding="wsHttpBinding" scheme="https" />
        </protocolMapping>    
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
