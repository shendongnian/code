    public override void Configure(IFunctionsHostBuilder builder)
     {
          builder.Services
               .AddSingleton<IPersonConfiguration, PersonConfiguration>()
               .AddSingleton<IProductConfiguration, ProductConfiguration>()
               .AddSingleton<IOrderConfiguration, OrderConfiguration>()
     }
