           public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors();
                services.AddMvc();
    
                services.AddDbContext<MyDbContext>(op => op.UseSqlServer(Configuration["DbConnection"]));
           }
