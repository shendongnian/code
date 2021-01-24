      <system.serviceModel>
        <behaviors>
          <endpointBehaviors>
            <behavior name="WebApplication1.CostServiceAspNetAjaxBehavior">
              <enableWebScript />
            </behavior>
          </endpointBehaviors>
          <serviceBehaviors>
            <behavior name="">
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
          multipleSiteBindingsEnabled="true" />
        <services>
          <service name="WebApplication1.CostService">
            <endpoint address="" behaviorConfiguration="WebApplication1.CostServiceAspNetAjaxBehavior"
              binding="webHttpBinding" contract="WebApplication1.CostService" />
          </service>
        </services>
      </system.serviceModel>
