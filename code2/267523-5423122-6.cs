      <add name="MyPolicy">
        <exceptionTypes>
          <add type="System.Exception, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            postHandlingAction="ThrowNewException" name="Exception">
            <exceptionHandlers>
              <add exceptionMessage="This is a sanitized message." 
                replaceExceptionType="System.Exception, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ReplaceHandler, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling"
                name="Replace Handler" />
            </exceptionHandlers>
          </add>
        </exceptionTypes>
      </add>
