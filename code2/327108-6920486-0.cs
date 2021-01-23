    <system.diagnostics>
        <sources>
          <source name="Source1" switchName="verboseSwitch">
            <listeners>
              <add name="console" />
            </listeners>
          </source>
          <source name="Source2" switchName="warningSwitch">
            <listeners>
              <add name="console" />
            </listeners>
          </source>
        </sources>
        <switches>
          <add name="verboseSwitch" value="Verbose" />
          <add name="warningSwitch" value="Information" />
        </switches>
        <sharedListeners>
          <add name="console" type="System.Diagnostics.ConsoleTraceListener" initializeData="false"/>
        </sharedListeners>
        <trace autoflush="true" indentsize="4">
          <listeners>
            <add name="console" />
          </listeners>
        </trace>
      </system.diagnostics>
    public void MethodOne()
    {
         TraceSource ts = new TraceSource("Source1");
    
         ts.TraceEvent(TraceEventType.Verbose, 0, "Called MethodOne");
        
         // do something that causes an error
         ts.TraceEvent(TraceEventType.Error, 0, "MethodOne threw an error");
    }
