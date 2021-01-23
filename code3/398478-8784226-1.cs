    <system.web> 
      <httpModules>
       <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.MicroKernel" />
      </httpModules>
    </system.web>
    <system.webServer>
     <modules>
      <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.MicroKernel" />
     </modules>
    </system.webServer>
