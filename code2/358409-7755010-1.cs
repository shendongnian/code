    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
      </configSections>
      <loggingConfiguration name="Logging Application Block" tracingEnabled="true"
        defaultCategory="System.ServiceModel" logWarningsWhenNoCategoriesMatch="true">
        <listeners>
          <add name="XML Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.XmlTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging"
            listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.XmlTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging"
            fileName="c:\\temp\\trace_framework.svclog" traceOutputOptions="DateTime, Timestamp, ProcessId, ThreadId" />
        </listeners>
        <categorySources>
          <add switchValue="All" name="System.ServiceModel">
            <listeners>
              <add name="XML Trace Listener" />
            </listeners>
          </add>
        </categorySources>
        <specialSources>
          <allEvents switchValue="All" name="All Events">
            <listeners>
              <add name="XML Trace Listener" />
            </listeners>
          </allEvents>
          <notProcessed switchValue="All" name="Unprocessed Category">
            <listeners>
              <add name="XML Trace Listener" />
            </listeners>
          </notProcessed>
          <errors switchValue="All" name="Logging Errors &amp; Warnings">
            <listeners>
              <add name="XML Trace Listener" />
            </listeners>
          </errors>
        </specialSources>
      </loggingConfiguration>
