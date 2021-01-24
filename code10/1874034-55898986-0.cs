    <system.serviceModel>
        <bindings>
          <wsHttpBinding>
            <binding name="wsHttp">
              <security mode="TransportWithMessageCredential">
                <message clientCredentialType="UserName"/>
              </security>
            </binding>
          </wsHttpBinding>
        </bindings>
        <services>
          <service name="WCFAuth.Service1" behaviorConfiguration="wsHttpBehavior">
            <endpoint address="" binding="wsHttpBinding" bindingConfiguration="wsHttp" contract="WCFAuth.IService1">
            </endpoint>
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior name="wsHttpBehavior">
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
              <serviceCredentials>
                <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="WCFAuth.ServiceAuthanticator, WCFAuth"/>
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
