    <system.serviceModel>
      <behaviors>
        <serviceBehaviors>
          <behavior name="DefaultServiceBehavior">
            <serviceMetadata httpsGetEnabled="true" />
            <serviceDebug includeExceptionDetailInFaults="true" />
            <serviceAuthorization principalPermissionMode="UseAspNetRoles" roleProviderName="SqlRoleProvider" />
              <serviceCredentials>
                <serviceCertificate x509FindType="FindBySubjectName" storeName="My" storeLocation="LocalMachine" findValue="SecureChannelCertificate" />
                <userNameAuthentication userNamePasswordValidationMode="MembershipProvider"  membershipProviderName="SqlMembershipProvider" />
             </serviceCredentials>
          </behavior>
        </serviceBehaviors>
      </behaviors>
      <bindings>
        <wsHttpBinding>
          <binding name="SecureBinding" messageEncoding="Mtom" maxReceivedMessageSize="4194304">
    <readerQuotas maxStringContentLength="4194304" maxArrayLength="4194304"/>
            <security mode="Message">
              <message clientCredentialType="UserName" negotiateServiceCredential="true" establishSecurityContext="true" />
            </security>
          </binding>
        </wsHttpBinding>
      </bindings>
    </system.serviceModel>
