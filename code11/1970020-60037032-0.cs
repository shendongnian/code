csharp
public class SomeTable
{
    public int Id { get; set; }
    public int Foobar { get; set; }
    public int Quantity { get; set; }
}
class MyDbContext : DbContext
{
    public DbSet<SomeTable> SomeTables { get; set; }
    public static readonly LoggerFactory DbCommandConsoleLoggerFactory
        = new LoggerFactory(new[] {
            new ConsoleLoggerProvider ((category, level) =>
                category == DbLoggerCategory.Database.Command.Name &&
                level == LogLevel.Trace, true)
        });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=...;Port=5432;Database=test;User Id=...;Password=...;")
        //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=test;Trusted_Connection=true")
                    .UseLoggerFactory(DbCommandConsoleLoggerFactory)
                    .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    } 
}
class Program
{
    static void Main(string[] args)
    {
        var context = new MyDbContext();
        var someTableData = context.SomeTables
                .GroupBy(x => x.Foobar)
                .Select(x => new { Foobar = x.Key, Quantity = x.Sum(y => y.Quantity) })
                .OrderByDescending(x => x.Quantity)
                .Take(10);
        Console.Write(someTableData);
        Console.ReadKey();
    }
}
/*csproj file contents below:
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <RootNamespace>ef_core3_playground</RootNamespace>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="3.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="3.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.1" />
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="1.1.0" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="3.1.1" />
  </ItemGroup>
</Project>
*/
I ended up getting the following SQL for respective providers:
SQL
--MS SQL
SELECT TOP(@__p_0) [s].[Foobar], SUM([s].[Quantity]) AS [Quantity]
FROM [SomeTables] AS [s]
GROUP BY [s].[Foobar]
ORDER BY SUM([s].[Quantity]) DESC
-- PG SQL
SELECT s."Foobar", SUM(s."Quantity")::INT AS "Quantity"
FROM "SomeTables" AS s
GROUP BY s."Foobar"
ORDER BY SUM(s."Quantity")::INT DESC
LIMIT @__p_0
This makes me wonder if it may be your provider/EF specific versions that give you that result? Although looking at the [diff between two npgsql releases][1] I can't see anything relaetd to the issue, but I would suggest you try upgrading all EF-related packages to `3.1.1` and repeat your test.
  [1]: https://github.com/npgsql/efcore.pg/compare/v3.1.0...v3.1.1
