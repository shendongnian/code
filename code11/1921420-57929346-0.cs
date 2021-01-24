    app.UseExceptionHandler(errorApp =>
      {
        errorApp.Run(async context =>
        {
          // Add CORS header to allow error message to be visible to Angular
          if (context.Request.Headers.TryGetValue("Origin", out StringValues origin))
          {
            context.Response.Headers.Add("Access-Control-Allow-Origin", origin.ToString());
          }
