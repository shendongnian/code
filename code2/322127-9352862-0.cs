    try this :
    <system.web>
        <compilation>  
        <assemblies>
            <add assembly="System.Web.WebPages.Razor, Version=1.0.0.0,Culture=neutral,PublicKeyToken=31BF3856AD364E35" />
        </assemblies>
        <buildProviders>
            <add extension=".cshtml" type="System.Web.WebPages.Razor.RazorBuildProvider, System.Web.WebPages.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </buildProviders>
        </compilation>
     </system.web>
