    public void ConfigureServices(IServiceCollection services)
            {
    
                //Only for preventing validation errors
                services.AddSingleton<IObjectModelValidator>(new NullObjectModelValidator());
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new ElapsedTimeJsonConverter()));
            }
