      <httpModules>
          <clear/>
          <!-- custom -->
          <add name="SomeHttpModule" type="SomeCompany.SomeProduct.SomeHttpModule"/>
          <!-- add back defaults, exlude PassportAuthentication, AnonymousIdentification, Profile -->
          <add name="OutputCache" type="System.Web.Caching.OutputCacheModule"/>
          <add name="Session" type="System.Web.SessionState.SessionStateModule"/>
          <add name="WindowsAuthentication" type="System.Web.Security.WindowsAuthenticationModule"/>
          <add name="FormsAuthentication" type="System.Web.Security.FormsAuthenticationModule"/>
          <add name="RoleManager" type="System.Web.Security.RoleManagerModule"/>
          <add name="UrlAuthorization" type="System.Web.Security.UrlAuthorizationModule"/>
          <add name="FileAuthorization" type="System.Web.Security.FileAuthorizationModule"/>
      </httpModules>
