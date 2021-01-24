    public void ConfigureServices(IServiceCollection services)
    {
         services.AddSwaggerGen(c =>
         {
             c.DocumentFilter<BasePathFilter>();
         });
     }
