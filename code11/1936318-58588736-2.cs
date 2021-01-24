      <system.serviceModel>
        <services>
          <service name="WcfService3.Service1">
            <endpoint address="" binding="netTcpBinding" 
              contract="WcfService3.IService1">
            </endpoint>
            <endpoint address="mex" binding="mexTcpBinding" 
              contract="IMetadataExchange" />
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior>
              <serviceMetadata />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
