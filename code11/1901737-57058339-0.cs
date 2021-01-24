public class ApplicationCustomDbContext : DbContext
{
    public ApplicationCustomDbContext () : base("name=DefaultConnectionCustom")
    {
    }
    // DbSet for your Entities
}
and in web.config you should specific connection string e.g.
<connectionStrings>
<add name="DefaultConnectionCustom" providerName="System.Data.SqlClient" connectionString="___" />
</connectionStrings>
