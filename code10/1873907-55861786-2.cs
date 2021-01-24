    public class Seeds
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            // Seed DB
            using (var _db = serviceProvider.GetRequiredService<TestMVC2_1Context>())
            {
                Console.WriteLine("\n Looking for a database... \n");
                // Look for a database
                if (!_db.Database.EnsureCreated())
                {
                    // Debug message
                    string message = "\n There is already a database. \n";
                    Console.WriteLine(message);
                    // DB has been seeded before
                }
                else
                {
                    // Debug message
                    string message = "\n A new database has been created. \n";
                    Console.WriteLine(message);
                    // Save the data samples
                    _db.SaveChanges();
                    // DB has been seeded now
                }
            }
        }
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            // Roles in the project
            string[] roleNames = { "Pilot", "Office" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // create custom users
            var officeUser = new AppUser
            {
                UserName = "paulita",
                Email = "paulita@",
                Password = "paulita"
            };
            var pilots = new AppUser[] {
                new AppUser
                {
                    Name = "pablito",
                    IdentityDocument = 80421514,
                    EmployeeNumber = 52641958,
                    UserName = "pcastellanos",
                    Email = "pablito@",
                    Password = "pablito",
                    BornDate = new DateTime(1990, 6, 20)
                },
                new AppUser
                {
                    Name = "pedrito",
                    IdentityDocument = 1098808192,
                    EmployeeNumber = 62549214,
                    UserName = "privero",
                    Email = "pedrito@",
                    Password = "pedrito",
                    BornDate = new DateTime(1992, 8, 10)
                }
            };
            foreach (var pilot in pilots)
            {
                var result = await UserManager.CreateAsync(pilot, pilot.Password);
                await UserManager.AddToRoleAsync(pilot, "Pilot");
            }
            await UserManager.CreateAsync(officeUser, officeUser.Password);
            await UserManager.AddToRoleAsync(officeUser, "Office");
            using (var _db = serviceProvider.GetRequiredService<TestMVC2_1Context>())
            {
                var myPilots = await UserManager.GetUsersInRoleAsync("Pilot");
                AppUser myUser = await UserManager.FindByNameAsync("pcastellanos");
                await _db.PilotTests.AddAsync(
                    new PilotTest
                    {
                        Pilot = myUser,
                    }
                );
                // Save the data samples
                _db.SaveChanges();
            }
        }
    }
