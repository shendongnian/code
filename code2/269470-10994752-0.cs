    <system.serviceModel>    
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" 
          multipleSiteBindingsEnabled="true" />
        <services>
          <service name="ModuleDossier.DSDossier" behaviorConfiguration="DSDossier_BehaviorConfig"></service>      
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior name="DSDossier_BehaviorConfig">
              <dataContractSerializer maxItemsInObjectGraph="2147483647"/>
            </behavior>
            <behavior name="DSDossier_BehaviorConfig1">
              <dataContractSerializer maxItemsInObjectGraph="2147483647"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
