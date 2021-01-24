    public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            var conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Adventures";
            services.AddDbContext<AdventuresContext>(options =>
                options.UseSqlServer(conn));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AdventuresContext>();
        }
