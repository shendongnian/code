        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ...
            if (env.IsStaging())
            {
                app.UsePathBase("/pre");
                app.UseStaticFiles();
            }
           ...
         }
