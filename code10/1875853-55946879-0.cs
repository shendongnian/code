cs
services.AddDbContextPool<ApplicationDbContext>(options =>
  options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
		b => b.MigrationsAssembly("AwesomeCMSCore")).UseOpenIddict());
Please let me know if you have any problem
