csharp
 public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost => configHost.AddEnvironmentVariables("ASPNETCORE_"))
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.SetBasePath(GetConfigDirectoryPath());
                    configApp.AddJsonFile("appsettings.json", optional: false);
                    configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureServices(ConfigureServices)
                .UseHostedService<MyBackgroundService>()
                .Build();
            await host.RunAsync();
        }
  private static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(hostBuilderContext.Configuration.GetConnectionString("Default")));
            services.AddTransient<IDbContextProvider<AppDbContext>, DefaultDbContextProvider>();
            services.AddTransient<IUnitOfWorkManager, UnitOfWorkManager>();
            services.AddTransient(typeof(IUnitOfWork), typeof(EfCoreUnitOfWork));
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(EfCoreReadOnlyRepositoryBase<>));
            services.AddTransient(typeof(IReadOnlyRepository<,>), typeof(EfCoreReadOnlyRepositoryBase<,>));
            services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepositoryBase<>));
            services.AddTransient(typeof(IRepository<,>), typeof(EfCoreRepositoryBase<,>));
            services.AddDistributedRedisCache(options => options.Configuration = hostBuilderContext.Configuration.GetSection("Redis:Configuration").Value);
            //Register AutoMapper profiles
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);
        }
Is implementing background service
  public class MyBackgroundService : BackgroundService
csharp
  public static class Extensions
    {
        public static IHostBuilder UseHostedService<T>(this IHostBuilder hostBuilder)
            where T : class, IHostedService, IDisposable
        {
            return hostBuilder.ConfigureServices(services =>
                services.AddHostedService<T>());
        }
    }
