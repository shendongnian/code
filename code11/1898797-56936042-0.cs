    var services = new ServiceCollection();
    services.AddDbContext<TaskManagerDbContext>(o =>
        o.UseInMemoryDatabase(Guid.NewGuid()));
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<TaskManagerDbContext>();
    var provider = services.BuildServiceProvider();
