    <system.diagnostics>
        <sources>
            <source name="System.Net" switchValue="Information, ActivityTracing">
                <listeners>
                    <add name="System.Net"
                         type="System.Diagnostics.TextWriterTraceListener"
                         initializeData="System.Net.trace.log" />
                </listeners>
            </source>
        </sources>
    </system.diagnostics>
