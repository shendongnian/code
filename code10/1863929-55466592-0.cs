c#
public class MySQLDbConfiguration : DbConfiguration
{
    public MySQLDbConfiguration()
    {
        SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
        SetProviderFactory(MySqlProviderInvariantName.ProviderName, new MySqlClientFactory());
    }
}
Declare the instance as readonly somewhere in the code, 
c#
private static readonly MySQLDbConfiguration DBConfig = new MySQLDbConfiguration();
and set the configuration **PRIOR TO using any EF features**
c#
DbConfiguration.SetConfiguration(DBConfig);
And our `app.config` now becomes
config
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <connectionStrings>
    <add name="MySQLDb" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;port=3306;database=sakila;uid=some_user;password=some_password"/>
    <add name="SQLDb" providerName="System.Data.SqlClient" connectionString="data source=USER-PC\SQLEXPRESS;initial catalog=MyDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"/>
  </connectionStrings>
</configuration>
