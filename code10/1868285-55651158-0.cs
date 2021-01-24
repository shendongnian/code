    <?xml version="1.0" encoding="UTF-8"?>
    <configuration>  
    <configSections />
       <appSettings file="c:\website\load.xml">
      </appSettings>
      <system.webServer>
        <security>
          <requestFiltering allowDoubleEscaping="true">
            <requestLimits maxAllowedContentLength="330301440" />
          </requestFiltering>
        </security>	
    	<handlers>
    		<add name="tesla.rem_*" path="tesla.rem" verb="*" type="X.API.tesla, api" preCondition="integratedMode" />
    	</handlers>	
        <validation validateIntegratedModeConfiguration="false" />
        <modules runAllManagedModulesForAllRequests="true" /> 
        <httpProtocol>
          <customHeaders>   
            <clear />
            <add name="X-XSS-Protection" value="0" />
            <add name="Strict-Transport-Security" value="max-avg=15552001; includeSubDomains; preload" />
          </customHeaders>
        </httpProtocol>   
        <directoryBrowse enabled="false" />	 
        <defaultDocument>
          <files> 
            <remove value="index.htm" />
            <remove value="index.html" />
            <remove value="Default.asp" />
            <remove value="Default.htm" />
            <remove value="iisstart.htm" />
            <remove value="default.aspx" />
          </files>
        </defaultDocument>
      </system.webServer>
      <system.web>   
        <pages validateRequest="false">
        </pages>
        <identity impersonate="false" />
        <compilation defaultLanguage="c#" debug="true">
          <assemblies>
            <add assembly="System.Runtime.Serialization.Formatters.Soap, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
            <add assembly="stdole, Version=7.0.3300.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Security, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
            <add assembly="System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Xml, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
            <add assembly="System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
            <add assembly="System.Web.Services, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.DirectoryServices, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.DirectoryServices.Protocols, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.EnterpriseServices, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.ServiceProcess, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
            <add assembly="System.Web.RegularExpressions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
          </assemblies>
        </compilation>   
        <customErrors mode="On" />
        <authentication mode="None" />
        <authorization>
          <allow users="*" />
        </authorization>
        <trace enabled="false" requestLimit="10" pageOutput="false" traceMode="SortByTime" localOnly="true" />
        <httpRuntime maxRequestLength="1048576" executionTimeout="3600" requestValidationMode="2.0" />
        <sessionState mode="InProc" stateConnectionString="tcpip=127.0.0.1:42424" sqlConnectionString="data source=127.0.0.1;Trusted_Connection=yes" cookieless="false" timeout="20" />
        <globalization requestEncoding="utf-8" responseEncoding="utf-8" />
      </system.web>
    </configuration>
