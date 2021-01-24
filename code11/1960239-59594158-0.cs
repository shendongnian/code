csharp
 public class CustomMigrationsSqlGenerator : MigrationsSqlGenerator
    {
        public CustomMigration(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }
        /// <param name="defaultValue">The default value for the column.</param>
        /// <param name="defaultValueSql">The SQL expression to use for the column's default constraint.</param>
        /// <param name="builder"></param>        
        /// <see cref="https://github.com/aspnet/EntityFrameworkCore/blob/v2.2.8/src/EFCore.Relational/Migrations/MigrationsSqlGenerator.cs#L1407"/>
        protected override void DefaultValue(object defaultValue, string defaultValueSql, MigrationCommandListBuilder builder)
        {
            Debugger.Launch();
            if (defaultValueSql != null) // I assume you only want to adapt specific values rather than whole type
            {
                if (Dependencies.SqlGenerationHelper is SqliteSqlGenerationHelper)
                { 
                builder
                    .Append(" DEFAULT (") 
                    .Append(defaultValueSql) //replace with your specific provider logic
                    .Append(")");
                    return;
                } else if (Dependencies.SqlGenerationHelper is SqlServerSqlGenerationHelper)
                {
                    builder
                        .Append(" DEFAULT (") 
                        .Append(defaultValueSql) //replace with your specific provider logic
                        .Append(")");
                    return;
                }
            }
            //fall back to default implementation
            base.DefaultValue(defaultValue, defaultValueSql, builder);
        }
    }
now that we've got a custom migration generator, we need to replace EF's default implementation:
csharp
var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
optionsBuilder.UseWhateverDbProviderForMigrations();
optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomMigrationsSqlGenerator>();
var context = new MyDbContext(optionsBuilder.Options);
I don't know enough on how you bootstrap the DbContext into your application and how you invoke the migrations, but assuming you are calling it from Package Manager console, the [following trick][3] will allow you to hijack the control:
csharp
 public class MigrationStartup: IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseWhateverDbProviderForMigrations();
            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomMigration>(); // this is the important bit
            return new MyDbContext(optionsBuilder.Options);
        }
    }
This approach can be extended to other types of SQL generated, by simply providing a respective override.
**One thing to note**: between EF 2.2 and EF 3 the `DefaultValue()` method signature has changed. So I guess I should warn you this is more of a hack and comes with certain support implications.
  [1]: https://stackoverflow.com/questions/52365060/entity-framework-core-2-1-multiple-providers
  [2]: https://github.com/aspnet/EntityFrameworkCore/blob/v2.2.8/src/EFCore.Relational/Migrations/MigrationsSqlGenerator.cs
  [3]: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
