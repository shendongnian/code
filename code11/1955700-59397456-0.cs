     services.AddConnections();
              services.AddDbContext<MyDatabaseContext>(options =>
                options.UseSqlServer(@"Server=localhost;Database=MyDatabase;Trusted_Connection=True;"));
                services.Configure<ConnectionString>(
            Configuration.GetSection(nameof(ConnectionString)));
                services.AddMvc()
                         .AddControllersAsServices();
                services.AddControllers().AddControllersAsServices();
