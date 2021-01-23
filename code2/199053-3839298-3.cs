    <system.serviceModel>
        <extensions>
          <behaviorExtensions>
            <add name="webAuthentication" type="WcfRestContrib.ServiceModel.Configuration.WebAuthentication.ConfigurationBehaviorElement, WcfRestContrib, Version=1.0.6.107, Culture=neutral, PublicKeyToken=89183999a8dc93b5"/>
            <add name="errorHandler" type="WcfRestContrib.ServiceModel.Configuration.ErrorHandler.BehaviorElement, WcfRestContrib, Version=1.0.6.107, Culture=neutral, PublicKeyToken=89183999a8dc93b5"/>
            <add name="webErrorHandler" type="WcfRestContrib.ServiceModel.Configuration.WebErrorHandler.ConfigurationBehaviorElement, WcfRestContrib, Version=1.0.6.107, Culture=neutral, PublicKeyToken=89183999a8dc93b5"/>
          </behaviorExtensions>
        </extensions>
        <behaviors>
          <serviceBehaviors>
            <behavior name="Rest">
              <webAuthentication requireSecureTransport="false" authenticationHandlerType="WcfRestContrib.ServiceModel.Dispatcher.WebBasicAuthenticationHandler, WcfRestContrib" usernamePasswordValidatorType="CMS.Backend.Services.SecurityValidator, CMS.Backend" source="CMS.Backend"/>
              <!--<webAuthentication requireSecureTransport="false" authenticationHandlerType="CMS.Backend.Services.WebBasicAuthenticationHandler, CMS.Backend" usernamePasswordValidatorType="CMS.Backend.Services.SecurityValidator, Website.Backend" source="CMS.Backend"/>-->
              <errorHandler errorHandlerType="WcfRestContrib.ServiceModel.Web.WebErrorHandler, WcfRestContrib"/>
              <webErrorHandler returnRawException="true" logHandlerType="Website.Backend.Services.LogHandler, Website.Backend" unhandledErrorMessage="An error has occured processing your request. Please contact technical support for further assistance."/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />
      </system.serviceModel>
