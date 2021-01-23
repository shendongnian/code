      <add name="WCF Exception Shielding">
        <exceptionTypes>
          <add type="System.Exception, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" postHandlingAction="ThrowNewException" name="Exception">
            <exceptionHandlers>
              <add exceptionMessage="Oops!"
                type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF.FaultContractExceptionHandler, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF"
                name="DefaultFaultContract Handler"
                faultContractType="Bursteg.Samples.WCFIntegration.ServiceContracts.ServiceFault, Bursteg.Samples.WCFIntegration.ServiceContracts">
                <mappings>
                  <add name="Id" source="{Guid}"/>
                  <add name="MessageText"  source="{Message}"/>
                </mappings>
              </add>
            </exceptionHandlers>
          </add>
