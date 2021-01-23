    <configuration>
      <system.net>
        <settings>
          <servicePointManager checkCertificateName="false" checkCertificateRevocationList="false" />
        </settings>
      </system.net>
      <system.serviceModel>
        <client>
          <endpoint ... behaviorConfiguration="DisableServiceCertificateValidation" />
        </client>
        <behaviors>
          <endpointBehaviors>
            <behavior name="DisableServiceCertificateValidation">
              <clientCredentials>
                <serviceCertificate>
                  <authentication certificateValidationMode="None"
                                  revocationMode="NoCheck" />
                </serviceCertificate>
              </clientCredentials>
            </behavior>
          </endpointBehaviors>
        </behaviors>
      </system.serviceModel>
    </configuration>
