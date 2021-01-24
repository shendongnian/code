    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
     AppDBContext appDbContext)
     {
    
                appDbContext.EnsureSeedDataForContext();
                app.UseHttpCacheHeaders();
                app.UseMvc();
    
            }
     }
