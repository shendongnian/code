     <system.serviceModel>
            <bindings>
              <wsHttpBinding>
                <binding name="NoneSecurity"
                  maxBufferPoolSize="12000000" maxReceivedMessageSize="12000000" useDefaultWebProxy="false">
                  <readerQuotas maxStringContentLength="12000000" maxArrayLength="12000000"/>
                  <security mode="None"/>
                </binding>
              </wsHttpBinding>
            </bindings>
            <services>
              <service behaviorConfiguration="Elong.GlobalHotel.Host.IHotelAPIBehavior"
                name="Elong.GlobalHotel.Host.IHotelAPI">
                <endpoint address="" binding="wsHttpBinding" bindingConfiguration="NoneSecurity" contract="Elong.GlobalHotel.Host.IIHotelAPI">
                  <identity>
                    <dns value="localhost" />
                  </identity>
                </endpoint>
                <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
              </service>
            </services>
            <behaviors>
              <serviceBehaviors>
                <behavior name="Elong.GlobalHotel.Host.IHotelAPIBehavior">
                  <serviceMetadata httpGetEnabled="true" />
                  <serviceDebug includeExceptionDetailInFaults="false" />
                </behavior>
              </serviceBehaviors>
            </behaviors>
          </system.serviceModel>
