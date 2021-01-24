c#
    public class Program {
        public static void ConfigureServices(HostBuilderContext context, IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkSqlite();
            serviceCollection.AddHostedService<DatabaseStartup>();
            serviceCollection.AddDbContextPool<HRDepartmentContext>(o =>
            {
                o.UseSqlite("Data Source=somepath\\employees.db");
            });
            // configure other services here
        }
        public static async Task<int> Main(string[] args)
        {
            using (var host = CreateHostBuilder(args).Build())
            {
                await host.StartAsync();
                var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
                // insert other console app code here
                lifetime.StopApplication();
                await host.WaitForShutdownAsync();
            }
            return 0;
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureServices(ConfigureServices);
    }
    public class DatabaseStartup : IHostedService {
        private readonly IServiceProvider serviceProvider;
        public DatabaseStartup(IServiceProvider serviceProvider){
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HRDepartmentContext>();
                await db.Database.EnsureCreated();
                // or 
                await db.Database.MigrateAsync();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
Since your console application then has a `CreateHostBuilder`, the entity framework command line tools can discover any custom configuration when creating migrations.
