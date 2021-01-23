    <system.serviceModel>
       <client>
          <endpoint name="RemoteSystemService" address="net.tcp://dev.remote-system.acme-corp.net:808/service.svc" behaviorConfiguration="remoteSystemNetTcpBindingBehavior" binding="netTcpBinding" contract="AcmeCorp.RemoteSystem.IRemoteSystemService">
             <identity>
                <dns value="dev.remote-system.acme" />
             </identity>
          </endpoint>
       </client>
       <bindings>
          <netTcpBinding>
             <binding>
                <security mode="Transport">
                   <transport clientCredentialType="Certificate" protectionLevel="EncryptAndSign" />
                </security>
             </binding>
          </netTcpBinding>
       </bindings>
       <behaviors>
          <endpointBehaviors>
             <behavior name="remoteSystemNetTcpBindingBehavior">
                <clientCredentials>
                   <clientCertificate findValue="CN=dev.clientSubsystem.acme" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectDistinguishedName" />
                   <serviceCertificate>
                      <authentication certificateValidationMode="PeerTrust" />
                   </serviceCertificate>
                </clientCredentials>
             </behavior>
          </endpointBehaviors>
       </behaviors>
    </system.serviceModel>
