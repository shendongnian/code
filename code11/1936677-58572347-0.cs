internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
{
    protected override void Seed(DbContext context)
    {
        //  This method will be called after migrating to the latest version.
        context.Database.ExecuteSqlCommand(File.ReadAllText(@"C:\FilePath.sql"));
    }
}
