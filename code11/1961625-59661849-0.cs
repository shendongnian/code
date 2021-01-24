csharp
public class MoodContextFactory : IDesignTimeDbContextFactory<BloggingContext>
{
	public MoodContextFactory CreateDbContext(string[] args)
	{
        var configurationBuilder = new ConfigurationBuilder();
        // you can also use user-secrets, environment-variables or what ever you need here
        configurationBuilder.AddJsonFile("appsettings.json");
        var configuration = configurationBuilder.Build();
		var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
		optionsBuilder.UseNpgsql(configuratio.GetConnectionString("My-ConnectionString"));
		return new BloggingContext(optionsBuilder.Options);
	}
}
