    <system.diagnostics>
      <sources>
        <source name="System.Net" tracemode="protocolonly">
          <listeners>
            <add name="System.Net" type="System.Diagnostics.TextWriterTraceListener" initializeData="network.log" />
          </listeners>
        </source>
      </sources>
    
      <switches>
        <add name="System.Net" value="Verbose"/>
      </switches>
    
      <trace autoflush="true" />
    </system.diagnostics>
