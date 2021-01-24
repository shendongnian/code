    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                // Custom exception middleware
                app.UseMiddleware<ExceptionMiddleware>();;
    
                app.UseMvc();
            }
