    public void ConfigureServices(IServiceCollection services)
    {
        ...
    
       services.AddMvc().AddJsonOptions(option => option.JsonSerializerOptions.MaxDepth = 2);
    
        ...
    }
