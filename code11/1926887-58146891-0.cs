        public void ConfigureServices(IServiceCollection services)
        {
                ....
                services.AddSession(options => {
                        options.IdleTimeout = <your session cookie timeout>;
                        options.Cookie.HttpOnly = true;
                    });
                ....
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
                ....
                app.UseSession();
                ....
        }
