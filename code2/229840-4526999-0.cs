     <type type="IMyService" mapTo="MyDataService" name="DataService">
          <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,
                                     Microsoft.Practices.Unity.Configuration">
            <constructor>
              <param name="connectionString" parameterType="string">
                <value value="AdventureWorks"/>
              </param>
              <param name="logger" parameterType="ILogger">
                <dependency />
              </param>
            </constructor> 
            <property name="Logger" propertyType="ILogger" />
            <method name="Initialize">
              <param name="connectionString" parameterType="string">
                <value value="contoso"/>
              </param>
              <param name="dataService" parameterType="IMyService">
                <dependency />
              </param>
            </method>
          </typeConfig>
        </type>
