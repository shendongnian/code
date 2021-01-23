    <system.serviceModel>
            <behaviors>
              <endpointBehaviors>
                <behavior name="WebApplication1.Service1AspNetAjaxBehavior">
                  <enableWebScript />
                </behavior>
              </endpointBehaviors>
            </behaviors>
            <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
              multipleSiteBindingsEnabled="true" />
            <services>
              <service name="WebApplication1.Service1">
                <endpoint address="" 
                  behaviorConfiguration="WebApplication1.Service1AspNetAjaxBehavior"
                  binding="webHttpBinding" contract="WebApplication1.Service1" />
              </service>
            </services>
          </system.serviceModel>
