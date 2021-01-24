    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    };
    app.Use(async (context, next) =>
    {
        try
        {
            await next.Invoke();
        }
        catch (Exception ex)
        {
            //var loggingService = context.RequestServices.GetService<ILoggingService>();
            //loggingService.Error(ex);
            Console.Error.WriteLine(ex.Message + " My " + ex.StackTrace);
            throw;
        }
    });
