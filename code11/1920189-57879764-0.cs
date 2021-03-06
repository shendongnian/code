     public void ConfigureServices(IServiceCollection services){
        // Add framework services.
        services.AddMvc()
            .AddMvcOptions(options =>
            {
                options.OutputFormatters.Add(new PascalCaseJsonProfileFormatter());
            });} 
