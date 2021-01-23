    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="logging" 
            type="CuttingEdge.Logging.LoggingSection, CuttingEdge.Logging" />
      </configSections>
      <logging defaultProvider="XmlLogger">
        <providers>
          <add name="XmlLogger"
         type="CuttingEdge.Logging.XmlFileLoggingProvider, CuttingEdge.Logging"
            path="log.xml" 
          />
        </providers>
      </logging>
      <system.web>
        <httpModules>
          <add name="ExceptionLogger"
    type="CuttingEdge.Logging.Web.AspNetExceptionLoggingModule, CuttingEdge.Logging"/>
        </httpModules>
      </system.web>
    </configuration>
