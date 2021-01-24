csharp
public class CustomDbConfiguration : DbConfiguration
{
    public CustomDbConfiguration()
    {
        SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
        SetProviderFactory(MySqlProviderInvariantName.ProviderName, new MySqlClientFactory());
    }
}
and use it like this:
csharp
class Program
{
    // 'DbConfiguration' should be treated as readonly. ONE AND ONLY ONE instance of 
    // 'DbConfiguration' is allowed in each AppDomain.
    private static readonly CustomDbConfiguration DBConfig = new CustomDbConfiguration();
    static void Main(string[] args)
    {
        // Explicitly set the configuration before using any features from EntityFramework.
        DbConfiguration.SetConfiguration(DBConfig);
        using (var dbContext = new MySQLDb())
        {
            var dbSet = dbContext.Set<Actor>();
            // Read data from database.
            var actors = dbSet.ToList();
        }
		
        using (var dbContext = new SQLDb())
        {
            var dbSet = dbContext.Set<User>();
            // Read data from database.
            var users = dbSet.ToList();
        }
    }
}
My `app.config` only contains info for connection string, as follow:
config
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <connectionStrings>
    <add name="MySQLDb" connectionString="server=localhost;port=3306;database=sakila;uid=some_id;password=some_password" providerName="MySql.Data.MySqlClient"/>
    <add name="SQLDb" connectionString="data source=.\SQLEXPRESS;initial catalog=some_db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
  [1]: https://docs.microsoft.com/en-us/ef/ef6/fundamentals/configuring/code-based
