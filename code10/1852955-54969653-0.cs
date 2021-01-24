public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FileManagerDbContext>
{
    public FileManagerDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<FileManagerDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlite(connectionString);
        return new FileManagerDbContext(builder.Options);
    }
}
3. In my Dockerfile, I had to explicitly copy `appsettings.json` next to the .csproj file. In my case this meant adding this command to the Dockerfile:
COPY ["src/appsettings.json", "WebApp/FileManager.WebApp/"]
After these steps the deployment was successful.
