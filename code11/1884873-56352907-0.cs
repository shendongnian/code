c#
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Migrations.History;
    namespace CustomizableMigrationsHistoryTableSample
    {
        public class MyHistoryContext : HistoryContext
        {
            public MyHistoryContext(DbConnection dbConnection, string defaultSchema)
                : base(dbConnection, defaultSchema)
            {
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "SYSTEM");
            }
        }
    }
2. Create class `ModelConfiguration`
c#
    using System.Data.Entity;
    namespace CustomizableMigrationsHistoryTableSample
    {
        public class ModelConfiguration : DbConfiguration
        {
            public ModelConfiguration()
            {
                this.SetHistoryContext("System.Data.SqlClient",
                    (connection, defaultSchema) => new MyHistoryContext(connection, defaultSchema));
            }
        }
    }
3. If you have existing migrations, you will need to delete migrations and database for execute the next commands:
For create `migrations` folder and `configuration` class:
bash
enable-migrations
For add migration `first_migration`
bash
add-migration <migration_name>
For apply migration(s) in data base
bash
update-database
Credits: [Ivan Stoev](https://stackoverflow.com/users/5202563/ivan-stoev)
> Before you start you need to know that you can customize the migrations history table only before you apply the first migration.. 
Detailed information: 
[Customizing the migrations history table](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/history-customization)
