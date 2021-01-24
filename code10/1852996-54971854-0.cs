cs
public class SQliteApplicationDbContext : ApplicationDbContext {}
public class SqlServerApplicationDbContext : ApplicationDbContext {}
Then register them as such:
cs
services.AddDbContext<SqlServerApplicationDbContext >(options => 
    options.UseSqlServer(Configuration.GetConnectionString(DatabaseProvider)));
services.AddDbContext<SQliteApplicationDbContext>(options =>   
    options.UseSqlite(Configuration.GetConnectionString(DatabaseProvider)));
services.AddScoped<ApplicationDbContext>((ctx) =>
{
    // fyi: would be better to implement the options pattern here
    DatabaseProvider = Configuration.GetValue<string>("SystemSettings:SystemProfile:DatabaseProvider");
    if (DatabaseProvider == "MSSQL")
        ctx.GetService<SqlServerApplicationDbContext >();
    else if (DatabaseProvider == "SQLite")
        ctx.GetService<SQliteApplicationDbContext>();
    else
        throw new Exception("Bad configuration");
});
Note that this makes the assumptions that asp.net core is configured to watch the changes in the `json` file.
