        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //your rest code
            using (var db = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                db.Database.Migrate();
            }
        }
