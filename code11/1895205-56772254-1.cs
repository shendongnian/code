     if (env.IsDevelopment())
     {          
          app.UseDeveloperExceptionPage();
     }
     else
     {
   				ExceptionHandlerOptions options;
				options.ExceptionHandler = new RequestDelegate();
				app.UseExceptionHandler(options);
     }
