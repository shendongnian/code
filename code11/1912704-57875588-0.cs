    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ITranscriptStore transcriptLogger)
          {
              if (env.IsDevelopment())
              {
                  app.UseDeveloperExceptionPage();
              }
              else
              {
                  app.UseHsts();
              }
    
              app.UseDefaultFiles();
              app.UseStaticFiles();
    
              //app.UseHttpsRedirection();
              app.UseMvc();
              app.UseTwitterAdapter();
    
              app.ApplicationServices.GetRequiredService<TwitterAdapter>().Use(new TranscriptLoggerMiddleware(transcriptLogger));
          }
