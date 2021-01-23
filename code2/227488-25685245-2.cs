        <system.diagnostics> 
            <trace autoflush="true" indentsize="4"> 
                  <listeners> 
                  <add name="consoleListener" type="System.Diagnostics.ConsoleTraceListener"/>
                <!--
                <add name="logListener" type="System.Diagnostics.TextWriterTraceListener" initializeData="TextWriterOutput.log" /> 
                <add name="EventLogListener" type="System.Diagnostics.EventLogTraceListener" initializeData="MyEventLog"/>
                 -->
                 <!--
                  Remove the Default listener to avoid duplicate messages
                  being sent to the debugger for display
                 -->
                 <remove name="Default" />
                 </listeners> 
            </trace> 
      </system.diagnostics>
