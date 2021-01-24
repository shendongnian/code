    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(ApiConstantVars.AZURE_POLICY);
            app.UseCors(ApiConstantVars.CORS_POLICY_NAME);
            app.UseAuthentication();
            app.UseMvc();
            app.Run(
                   async context =>
                   {
                       var handler = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                       if (handler != null && handler.Error != null)
                       {
                           var errorModel = new OperationResult
                           {
                               IsSuccess = false,
                           };
                            //Handle the JSON request to respond in its origin format
                           if (context.Request.ContentType.ToUpper().IndexOf("JSON") != -1)
                           {
                               context.Response.ContentType = "application/json";
                               context.Response.StatusCode = 400; //Set the Status Code to responde JSON Failed requests
                               await context.Response
                               .WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { error = "Unhandled internal error", success = false, origin = context.Request.Path }))
                               .ConfigureAwait(false);
                           }
                           else
                           {
                               context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                               await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(handler.Error.Message))
                                   .ConfigureAwait(false);
                           }
                       }
                       else
                       {
                           context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                           await context.Response
                               .WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { message = "Unhandled internal error" }))
                               .ConfigureAwait(false);
                       }
                   });
        }
