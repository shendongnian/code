    <system.serviceModel>
      <services>
        <service behaviorConfiguration="MyServiceBehavior" name="BelfryImages.QueryService.Implementation.HelloWorld">
          <endpoint address="HelloWorld" binding="wsHttpBinding" name="HelloWorld" contract="BelfryImages.QueryService.Contracts.IHelloWorld" />
        </service>
      </services>
      <behaviors>
        <serviceBehaviors>
          <behavior name="MyServiceBehavior">
            <serviceMetadata httpGetEnabled="true" />
            <serviceDebug includeExceptionDetailInFaults="true" />
          </behavior>
        </serviceBehaviors>
      </behaviors>
      <bindings>
      </bindings>
    </system.serviceModel>
