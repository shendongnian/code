     services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ProjectDbContext>()
               .AddDefaultTokenProviders();
       services.AddDbContext<ProjectDbContext>(options => 
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                
