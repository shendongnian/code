    <system.diagnostics>
        <trace autoflush="true" />
        <sources>
          <source name="System.Net">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.HttpListener">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.Sockets">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.Cache">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add name="System.Net"
           type="System.Diagnostics.TextWriterTraceListener"
           initializeData="System.Net.trace.log"
           traceOutputOptions = "ProcessId, DateTime"/>
        </sharedListeners>
        <switches>
          <add name="System.Net" value="Verbose" />
          <add name="System.Net.Sockets" value="Verbose" />
          <add name="System.Net.Cache" value="Verbose" />
          <add name="System.Net.HttpListener" value="Verbose" />
        </switches>
      </system.diagnostics>
