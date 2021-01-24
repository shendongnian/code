          //this one you are already adding it according to your code
          services.AddDbContext<CSDDashboardContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("CSDDashboardContext")));
         //Notice this is NOT the same class... Assuming this is a valid DBContext.  You need to add this class as well.
          services.AddDbContext<CSSDDashboardContext >(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("CSDDashboardContext")));
