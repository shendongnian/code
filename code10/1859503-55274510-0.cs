    app.Use(async (context, next) =>
        {
            if (context.User.Identity.IsAuthenticated)
            {
                await next.Invoke();
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        });
    app.UseSignalR(routes =>
    {
        routes.MapHub<ChatHub>("/hubs/chat");
    });  
