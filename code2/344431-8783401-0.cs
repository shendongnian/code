    <configuration>
        <system.serviceModel>
            <services>
                <service name="com.aschneider.examples.wcf.services.EchoService">
                    <host>
                        <baseAddresses>
                            <add baseAddress="net.pipe://localhost/EchoService"/>
                        </baseAddresses>
                    </host>
                </service>
            </services>
            <behaviors>
                <serviceBehaviors></serviceBehaviors>
            </behaviors>
        </system.serviceModel>
    </configuration>
