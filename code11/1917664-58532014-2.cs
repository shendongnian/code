    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    //
    using NSG.WebSrv;
    using NSG.WebSrv.Domain.Entities;
    //
    namespace NSG.WebSrv_Tests
    {
        public class UnitTestFixture : IDisposable
        {
            //
            static private SqliteConnection sqliteConnection;
            static public ApplicationDbContext db_context;
            static public UserManager<ApplicationUser> userManager;
            static public RoleManager<ApplicationRole> roleManager;
            //
            public UnitTestFixture()
            {
            }
            //
            public void UnitTestSetup()
            {
                // Build service colection to create identity UserManager and RoleManager. 
                IServiceCollection serviceCollection = new ServiceCollection();
                // Add ASP.NET Core Identity database in memory.
                sqliteConnection = new SqliteConnection("DataSource=:memory:");
                serviceCollection.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlite(sqliteConnection)
                );
                //
                db_context = serviceCollection.BuildServiceProvider()
                    .GetService<ApplicationDbContext>();
                db_context.Database.OpenConnection();
                db_context.Database.EnsureCreated();
                // Add Identity using in memory database to create UserManager and RoleManager.
                serviceCollection.AddApplicationIdentity();
                // Get UserManager and RoleManager.
                userManager = serviceCollection.BuildServiceProvider().GetService<UserManager<ApplicationUser>>();
                roleManager = serviceCollection.BuildServiceProvider().GetService<RoleManager<ApplicationRole>>();
            }
            //
            /// <summary>
            /// Cleanup resources
            /// </summary>
            public void Dispose()
            {
                if(db_context != null)
                {
                    db_context.Database.EnsureDeleted();
                    db_context.Dispose();
                }
                sqliteConnection.Close();
            }
        }
    }
