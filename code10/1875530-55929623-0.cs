    1 public void ConfigureServices(IServiceCollection services)
    2 {
    3    services.AddMvc(setup => {
    4      //...mvc setup...
    5    }).AddFluentValidation(configuration => configuration
    6      .RegisterValidatorsFromAssemblyContaining<Startup>());
    7 }
