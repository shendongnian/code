     public void ConfigureServices(IServiceCollection services)
        {
          ....
       services.AddSession(options =>
            {
             
            });
    ....
       }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
    .....
            app.UseSession();
    ....
        }
