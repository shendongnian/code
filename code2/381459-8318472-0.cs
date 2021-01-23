    <system.diagnostics>
    <sources>
      <source name="System.ServiceModel"
             switchValue="All">
        <listeners>
          <add name="xmlTraceListener" />
        </listeners>
      </source>
      <source name="System.ServiceModel.MessageLogging"
       switchValue="All">
        <listeners>
          <add name="xmlTraceListener" />
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add name="xmlTraceListener"
       type="System.Diagnostics.XmlWriterTraceListener"
        initializeData="ApplicationTrace.svclog" />
    </sharedListeners>
    <trace autoflush="true" />
    </system.diagnostics>
