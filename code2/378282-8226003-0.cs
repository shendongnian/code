    <system.webServer>
      <modules runAllManagedModulesForAllRequests="true">
        <remove name="WebDAVModule" />
        <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
      </modules>
    </system.webServer>
