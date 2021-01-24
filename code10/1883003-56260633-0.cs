    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddEventSourceLogger();
                loggerFactory.AddDebug(); //You can add this to your startup
                loggerFactory.AddFile("Logs/test-logs-{Date}.txt");
            }
            loggerFactory.AddEventSourceLogger();
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/test-logs-{Date}.txt", LogLevel.Warning);}
