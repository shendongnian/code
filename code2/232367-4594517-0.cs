    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <connectionStrings>
        <add name="MembershipConnectionString" connectionString="connectionstringdetails" providerName="System.Data.SqlClient" />
      </connectionStrings>
      <system.web>
        <membership defaultProvider="DefaultSqlMembershipProvider">
          <providers>
            <clear />
            <add name="DefaultSqlMembershipProvider" connectionStringName="MembershipConnectionString" type="System.Web.Security.SqlMembershipProvider" />
          </providers>
        </membership>
      </system.web>
    </configuration>
