    <system.web.webPages.razor>
        <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.2.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            (... other references ...)
            <add namespace="Microsoft.CSharp" />  <-- Add this
            (...)
          </namespaces>
        </pages>
      </system.web.webPages.razor>
