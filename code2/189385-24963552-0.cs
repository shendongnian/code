      <connectionStrings>
        <clear/>
        <add name="DbEntities" connectionString="..." providerName="System.Data.SqlClient" />
      </connectionStrings>
      ...
      <roleManager defaultProvider="DefaultRoleProvider" enabled="true">
        <providers>
          <clear/>
          <add name="DefaultRoleProvider" ... />
        </providers>
      </roleManager>
    
