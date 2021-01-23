    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <system.serviceModel>
            <behaviors>
                <serviceBehaviors>
                    <behavior name="ClientServiceBehavior">
                        <serviceDebug includeExceptionDetailInFaults="false" />
                    </behavior>
                </serviceBehaviors>
            </behaviors>
            <services>
                <service behaviorConfiguration="ClientServiceBehavior"
                    name="WPFServiceHost1.Service.ClientService">
                    <endpoint address="ClientService" binding="basicHttpBinding" contract="WPFServiceHost1.Service.IClientService"/>
                    <host>
                        <baseAddresses>
                            <add baseAddress="http://localhost:8010" />
                        </baseAddresses>
                    </host>
                </service>
            </services>
        </system.serviceModel>
    </configuration>
