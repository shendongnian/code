c#
namespace MyMapper
{
   [Database]
   public class MyDataContext : DataContext
   {
      public MyDataContext() : base(new MySqlConnection(Properties.Settings.Default.myConnectionString)) { }
      public Table<ElementId> ElementIds;
   }
}
but now the following exception is thrown:
You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near '[ElementId]([IntegerValue])
VALUES (88)' at line 1
it looks that the query is not being formatted as MySQL
**UPDATE:**
MySQL support requires NuGet Packages:
- A fully-managed ADO.NET driver for MySQL. The most popular options are:
 - **MySQL.Data**: https://dev.mysql.com/downloads/connector/net/ (NuGet: https://www.nuget.org/packages/MySql.Data/)
 - **SQLite**: https://www.sqlite.org/index.html (NuGet: https:// www.nuget.org/packages/System.Data.SQLite/ or https:// www.nuget.org/packages/System.Data.SQLite.Core/)
- Entity Framework (https://docs.microsoft.com/en-us/ef/)
 - **Entity Framework**: https://www.nuget.org/packages/EntityFramework/
 - **Entity Framework Core**: https:// www.nuget.org/packages/Microsoft.EntityFrameworkCore/
I have used MySQL.Data and Entity Framework 6 (EF6): https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html
The reason to choose EF6 is because EF Core does support Type Per Type (https://entityframework.net/tpt) at the time of writing this answer (https://github.com/aspnet/EntityFrameworkCore/issues/2266)
DataContext in MyDataContext.cs:
c#
namespace MyMapper
{
   [DbConfigurationType(typeof(MySqlEFConfiguration))]
   public class MyDataContext : DbContext
   {
      public DbSet<BaseClass> BaseClass{ get; set; }
      public DbSet<ElementId> ElementId { get; set; }
      public MyDataContext () : base(new MySqlConnection(Properties.Settings.Default.myConnectionString).ConnectionString) { }
      protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
      {
         dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // to avoid pluralization of the tables
         // EntityTypeConfiguration<T>
         dbModelBuilder.Configurations.Add(new BaseClassConfiguration());
         dbModelBuilder.Configurations.Add(new ElementIdConfiguration());
      }
   }
}
