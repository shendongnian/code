    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            //setup our DI
            // Add framework services.            
            services.AddDbContext<ApplicationDbContext>(options=> {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsoleAppIdentity;Trusted_Connection=True;ConnectRetryCount=0");
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IUserCreationService, UserCreationService>();
            // Build the IoC from the service collection
            var provider = services.BuildServiceProvider();
            var userService = provider.GetService<IUserCreationService>();
            userService.CreateUser().GetAwaiter().GetResult();
            Console.ReadKey();
        }
        public interface IUserCreationService
        {
            Task CreateUser();
        }
        public class UserCreationService : IUserCreationService
        {
            public readonly UserManager<ApplicationUser> userManager;
            public UserCreationService(UserManager<ApplicationUser> userManager)
            {
                this.userManager = userManager;
            }
            public async Task CreateUser()
            {
                var user = new ApplicationUser { UserName = "TestUser", Email = "test@example.com" };
                var result = await this.userManager.CreateAsync(user, "Test@123");
                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
                else
                {
                    Console.WriteLine("Done.");
                }
            }
        }
    }
