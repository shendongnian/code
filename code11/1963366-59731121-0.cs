public static class Extensions
{
	public static IServiceCollection UseMyDatabase(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
		return services;
	}
}
Startup.cs:
services.UseMyDatabase(Configuration.GetConnectionString("Connection"));
