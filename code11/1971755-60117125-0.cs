c#
    public interface IDbInitializer
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize();
        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }
**DbInitializer.cs**
c#
    public class DbInitializer : IDbInitializer {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializer (IServiceScopeFactory scopeFactory) {
            this._scopeFactory = scopeFactory;
        }
        public void Initialize () {
            using (var serviceScope = _scopeFactory.CreateScope ()) {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext> ()) {
                    context.Database.Migrate ();
                }
            }
        }
        public void SeedData () {
            using (var serviceScope = _scopeFactory.CreateScope ()) {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext> ()) {
                   
                    //add admin user and base role
                    if (!context.Users.Any ()) {
                        var adminUser = new User {
                            IsActive = true,
                            Username = "admin",
                            Password = "admin1234",
                            SerialNumber = Guid.NewGuid ().ToString ()
                        };
                        context.Users.Add (adminUser);
                    }
                    context.SaveChanges ();
                }
            }
        }
    }
for using this service you can add it to your service collection :
c#
 // StartUp.cs -- ConfigureServices method
 services.AddScoped<IDbInitializer, DbInitializer> ()
because i want to use this class every time my program starts i'm using injected service this way :
 c#
 // StartUp.cs -- Configure method
         var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ();
         using (var scope = scopeFactory.CreateScope ()) {
            var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer> ();
            dbInitializer.Initialize ();
            dbInitializer.SeedData ();
         }
         
