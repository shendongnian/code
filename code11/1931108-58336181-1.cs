    public void ConfigureServices(IServiceCollection services)
            {
                services.AddRazorPages();
                services.AddServerSideBlazor();
                services.AddSingleton<WeatherForecastService>();
                services.AddSingleton<Models.TestViewModel>();
            }
