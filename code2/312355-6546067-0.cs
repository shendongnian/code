        <?xml version="1.0"?>
        <configuration>
         <system.serviceModel>
        <behaviors>
            <serviceBehaviors>
                <behavior name="ServiceCredentialsBehavior">
                    <serviceCredentials>
                        <serviceCertificate findValue="cn=cool" storeName="TrustedPeople" storeLocation="CurrentUser" />
                    </serviceCredentials>
                    <serviceMetadata httpGetEnabled="true" />
                </behavior>
            </serviceBehaviors>
        </behaviors>
        <services>
            <service behaviorConfiguration="ServiceCredentialsBehavior" name="Service">
                <endpoint address="" binding="wsHttpBinding" bindingConfiguration="MessageAndUserName" name="SecuredByTransportEndpoint" contract="IService"/>
            </service>
        </services>
        <bindings>
            <wsHttpBinding>
                <binding name="MessageAndUserName">
                    <security mode="Message">
                        <message clientCredentialType="UserName"/>
                    </security>
                </binding>
            </wsHttpBinding>
        </bindings>
        <client/>
    </system.serviceModel>
    <system.web>
        <compilation debug="true"/>
    </system.web>
