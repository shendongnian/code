        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            
            // AFAIK in netcoreapp2.0 this was not required
            // to use CORS with attributes.
            // This is now required, as otherwise a runtime exception is thrown
            // UseCors applies a global CORS policy, when no policy name is given
            // the default CORS policy is applied
            app.UseCors(); 
            if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			app.UseHttpsRedirection();
            
            app.UseAuthorization();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
