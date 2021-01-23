&lt;system.diagnostics&gt;
  &lt;sources&gt;
    &lt;source name="System.ServiceModel"
            switchValue="Information, ActivityTracing"
            propagateActivity="true"&gt;
      &lt;listeners&gt;
        &lt;add name="traceListener"
            type="System.Diagnostics.XmlWriterTraceListener"
            initializeData= "c:\temp\WEBTraces.log" /&gt;
      &lt;/listeners&gt;
    &lt;/source&gt;
  &lt;/sources&gt;
&lt;/system.diagnostics&gt;
