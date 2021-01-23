    <system.web>
      <authentication mode="Windows" />
      <identity impersonate="true"/>
    </system.web>
     <!-- you need the following lines of code to bypass errors, concerning type of Application Pool (integrated pipeline or classic) -->
    <system.webServer>
       <validation validateIntegratedModeConfiguration="false"/>
    </system.webServer>
