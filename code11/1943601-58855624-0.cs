    services.AddTransient<Service1>();
    services.AddTransient<Service2>();
    services.AddTransient<MySqlInterceptor>();
    // resolve the instalce of the interceptor
    var serviceProvider = services.BuildServiceProvider();
    var interceptor = serviceProvider.GetService<MySqlInterceptor>();
    // configure mysql context and interceptor
    services.AddDbContext<MySqlContext>(options => options
     .UseMySql(Configuration.GetConnectionString("MySql"))
     .AddInterceptors(interceptor))
